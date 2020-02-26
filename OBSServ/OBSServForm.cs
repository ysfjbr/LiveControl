using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace OBSServ
{
    public partial class OBSserv : Form
    {
        
        TcpClient clientSocket = new TcpClient();
        
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        Thread ctThread;
        string clName = "";
        bool Connected = false;
        string comstr = null;
        int connAttemps = 0;

        //Thread[] commandThread = new Thread[100];
        //int threadID = 0;

        public OBSserv()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
        }


        private void sendData(string Str, bool toConnect = false)
        {
            if (Connected || toConnect)
            {
                byte[] outStream = Encoding.ASCII.GetBytes(Str + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
        }

        /*static List<string> Split(string str, int chunkSize)
        {
            List<string> res = new List<string>();
            int ch = 0;
            //str = "%START%" + str + "%END%";
            int stringLength = str.Length;
            
            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength) chunkSize = stringLength - i;
                res.Add(str.Substring(i, chunkSize));
                ch++;
            }
            return res;
        }*/

        private void getMessage()
        {
            try
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();
                    int buffSize = 0;
                    byte[] inStream = new byte[10025];
                    buffSize = clientSocket.ReceiveBufferSize;
                    serverStream.Read(inStream, 0, (Int32)inStream.Length);
                    string returndata = Encoding.ASCII.GetString(inStream);
                    readData = "" + returndata;
                    msg();
                }
            }catch(Exception ex)
            {
                disconnetServer();
                try
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + " Error: " + ex.Message;
                }catch(Exception ex2)
                {

                }
            }
        }

        private void doCommand(string str)
        {
            data_str.Text = str;

            str = data_str.Text;

            data_str.Text = "";

            if (str.StartsWith("CON__"))
            {
                getDevices(str);
            }
            else if (str.StartsWith("OBSC_"))
            {
                //textBox1.Text = textBox1.Text + Environment.NewLine + " >> obs command " + str.Substring(5);
                comstr = str.Substring(5);
                Thread commThread = new Thread(exec_comm);
                commThread.Start();
                /*comstr = str.Substring(5);
                commandThread[threadID] = new Thread(exec_comm);
                commandThread[threadID].Start();
                threadID++;
                if (threadID >= 99)
                    threadID = 0;*/
            }
            else if (str.StartsWith("OBS^"))
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + " " + str;
                string[] obsResult = str.Split('^');
                if(obsResult[1] == clName)
                {
                    if (obsResult[2] == "TOOBS")
                    {
                        comstr = obsResult[3];
                        Thread commThread = new Thread(exec_comm);
                        commThread.Start();
                    }
                }
            }
            else if (str.StartsWith("OBSText^"))
            {
                string[] obsResult = str.Split('^');

                comstr = "/command=GetSourceSettings,sourceName=\"" + obsResult[1] + "\"";
                data_str.Text = getCommandOutput();
                bool inFile = false;
                SSource source = new SSource();
                try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    source = js.Deserialize<SSource>(correctJSON(data_str.Text));
                    try
                    {
                        inFile = source.sourceSettings.read_from_file;
                    }
                    catch (Exception ex)
                    {

                    }
                }catch (Exception ex1)
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + "ErrorJSON :  " + ex1.Message + Environment.NewLine + data_str.Text;
                }

                if(inFile)
                {
                    try
                    {
                        File.WriteAllText(source.sourceSettings.file, decodeString(obsResult[2]));
                    }
                    catch(Exception ex)
                    {
                        textBox1.Text = textBox1.Text + Environment.NewLine + "Error :  " + ex.Message;
                    }
                }
                else
                {
                    comstr = "/command=SetSourceSettings,sourceName=\"" + obsResult[1] + "\",sourceSettings=text=\"" + decodeString(obsResult[2]) + "\"";
                    Thread commThread = new Thread(exec_comm);
                    commThread.Start();
                }

                   
            }
            else
            {
                data_str.Text = str;
                if (data_str.Text == "")
                {
                    data_str.Text = "Connection Failed! check your name and password";
                    textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + data_str.Text;
                    disconnetServer();
                }
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + data_str.Text ;
            }
                
        }

        private void getDevices(string command)
        {
            listBox1.Items.Clear();
            foreach (string s in command.Substring(5).Split('%'))
            {
                listBox1.Items.Add(s);
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                doCommand(readData);
        }

        private void OBSserv_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public string getCommandOutput()
        {
            string output = "";

            bool obs_run = false;
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect("127.0.0.1", int.Parse(obs_port_txt.Text));
                    obs_run = true;
                }
                catch (Exception)
                {
                    try
                    {
                        if (obsPath_txt.Text != "" && File.Exists(obsPath_txt.Text))
                        {
                            var p = new Process();
                            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(obsPath_txt.Text);
                            p.StartInfo.FileName = obsPath_txt.Text;
                            p.Start();
                            obs_run = true;
                            //Thread.Sleep(300);
                        }
                    }
                    catch (Exception ex)
                    {
                        obs_run = false;
                    }

                }
            }
            if (obs_run)
            {
                try
                {
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = @"OBSCommand\OBSCommand.exe",
                            Arguments = comstr,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };

                    process.Start();

                    while (!process.StandardOutput.EndOfStream)
                    {
                        var line = process.StandardOutput.ReadLine();
                        output += line;
                    }

                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
            }

            return output;
        }

        public void exec_comm()
        {
            //textBox1.Text += "COMMAND >>> " + comstr;
            sendCommandOutput(clName, comstr, getCommandOutput());
            /*
            List<string> outmsg = Split(output, 1000);
            int oid = new Random().Next(1000);
            int oorder = 0;
            foreach (string os in outmsg)
            {
                sendData("OBS^" + clientName_txt.Text + "^" + oid.ToString()+ "^" + oorder.ToString() + "^" + outmsg.Count.ToString() + "^" + os);
                oorder++;
                Thread.Sleep(200);
            }*/
            
        }

        private void sendCommandOutput(string clName, string comstr, string output)
        {
            string outType = "other";
            string outRes = "";

            if (comstr.Contains("ListSceneCollections"))
            {
                try
                {
                    outType = "SceneCollections";
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Scenelist slist = js.Deserialize<Scenelist>(correctJSON(output));
                    outRes = js.Serialize(new SceneListNames(slist)).ToString();
                }
                catch (Exception ex)
                {

                }

            }
            else if (comstr.Contains("GetSceneList"))
            {
                try
                {
                    outType = "SceneList";
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Scenelist slist = js.Deserialize<Scenelist>(correctJSON(output));
                    outRes = js.Serialize(new SceneListNames(slist)).ToString();
                }
                catch (Exception ex)
                {

                }
            }
            else if (comstr.Contains("GetSourceSettings"))
            {
                try
                {
                    outType = "SourceSettings";
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    SSource source = js.Deserialize<SSource>(correctJSON(output));
                    if (source.sourceType == "text_gdiplus")
                    {
                        try
                        {
                            source.sourceSettings.text = encodeString(File.ReadAllText(source.sourceSettings.file));
                        }
                        catch(Exception ex)
                        {
                            source.sourceSettings.text = encodeString(source.sourceSettings.text);
                        }
                    }
                    outRes = js.Serialize(source).ToString();
                }
                catch (Exception ex)
                {
                    textBox1.Text += ex.Message;
                }
            }
            else if (comstr.Contains("GetStreamingStatus"))
            {
                try
                {
                    outType = "StreamingStatus";
                    outRes = correctJSON(output);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                outRes = output;
            }
            

            sendData("OBS^" + clName + "^" + outType + "^" + outRes);
        }

        static string encodeString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        static string decodeString(string c)
        {
            var bytes = new byte[c.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(c.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }

        private string correctJSON(string str)
        {
            str = str.Replace("current-scene", "current_scene");
            str = str.Replace("preview-only", "preview_only");
            str = str.Replace("message-id", "message_id");
            str = str.Replace("recording-paused", "recording_paused");
            str = str.Replace("stream-timecode", "stream_timecode");
            str = str.Replace("rec-timecode", "rec_timecode");
            str = str.Substring(0, str.IndexOf("}Ok") + 1);

            return str;
        }

        private void conn_btn_Click(object sender, EventArgs e)
        {
            if (Connected)
                disconnetServer();
            else
                connectServer();
        }

        private void connectServer()
        {
            readData = "Conected to Stream Server ...";
            msg();
            try
            {
                clientSocket.Close();
                clientSocket = new TcpClient();
                clientSocket.Connect(ip_txt.Text, int.Parse(port_txt.Text));
                serverStream = clientSocket.GetStream();

                sendData("OBS_" + clientName_txt.Text + "&" + pass_txt.Text, true);

                ctThread = new Thread(getMessage);
                ctThread.Start();
                clName = clientName_txt.Text;
                //command_timer.Enabled = false;
                Connected = true;
                data_str.BackColor = Color.Green;
                conn_btn.Text = "Disonnect !";
                saveSettings();
                downloadSceneColl();
            }
            catch (Exception ex)
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendData("ch_Conn");
        }
        
    

        private void button1_Click(object sender, EventArgs e)
        {
            obspath_open.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(connAttemps > 120)
            {
                disconnetServer();
                connAttemps = 0;
                Thread.Sleep(500);
            }

            if (!Connected)
                connectServer();
            Thread.Sleep(500);
            //sendData("ch_Conn");
            connAttemps++;
        }

        private void saveSettings()
        {
            Properties.Settings.Default["ip"]           = ip_txt.Text;
            Properties.Settings.Default["port"]         = int.Parse(port_txt.Text);
            Properties.Settings.Default["clientName"]   = clientName_txt.Text;
            Properties.Settings.Default["clientPass"]   = pass_txt.Text;
            Properties.Settings.Default["obsPath"]      = obsPath_txt.Text;
            Properties.Settings.Default["obsport"]      = obs_port_txt.Text;

            Properties.Settings.Default.Save();
        }
        private void loadSettings()
        {
            if (Properties.Settings.Default["ip"].ToString() != "")
            {
                ip_txt.Text = Properties.Settings.Default["ip"].ToString();
                port_txt.Text = Properties.Settings.Default["port"].ToString();
                clientName_txt.Text = Properties.Settings.Default["clientName"].ToString();
                pass_txt.Text = Properties.Settings.Default["clientPass"].ToString();
                obsPath_txt.Text = Properties.Settings.Default["obsPath"].ToString();
                obs_port_txt.Text = Properties.Settings.Default["obsport"].ToString();
            }

            downloadSceneColl();

        }

        private void obspath_open_FileOk(object sender, CancelEventArgs e)
        {
            obsPath_txt.Text = obspath_open.FileName;
            saveSettings();
        }

        private void disconnetServer()
        {
            data_str.BackColor = Color.Gray;
            
            serverStream.Close();
            clientSocket.Close();

            Connected = false;
            clName = "";
            try
            {
                conn_btn.Text = "Connect !";
                listBox1.Items.Clear();
            }
            catch(Exception ex) { }
            try
            {
                ctThread.Abort();
            } catch (Exception ex) { }
        }

        private void data_str_Click(object sender, EventArgs e)
        {

        }

        private void obs_port_txt_TextChanged(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(encodeString(File.ReadAllText(@"c:\obs_content\text.txt")));
            /*string t = @"{  'current_scene': 'Main2',  'message_id': 'TBnSWenS3PwW5KHE',  'scenes': [    {      'name': 'Black',      'sources': [        {          'cx': 0.0,          'cy': 0.0,          'id': 5,          'locked': false,          'name': 'VLC Video Source',          'render': true,          'source_cx': 0,          'source_cy': 0,          'type': 'vlc_source',          'volume': 1.0,          'x': 0.0,          'y': -279.0        }      ]    },    {      'name': 'Main',      'sources': [        {          'cx': 1920.0,          'cy': 1134.0,          'id': 6,          'locked': false,          'name': 'Browser',          'render': true,          'source_cx': 1290,          'source_cy': 762,          'type': 'browser_source',          'volume': 0.67712104320526123,          'x': 1.0,          'y': -4.0        }      ]    },    {      'name': 'Main2',      'sources': [        {          'cx': 228.84745788574219,          'cy': 48.0,          'id': 9,          'locked': false,          'name': 'v1 2',          'render': true,          'source_cx': 172,          'source_cy': 36,          'type': 'text_gdiplus',          'volume': 1.0,          'x': 1555.0,          'y': 843.0        },        {          'cx': 157.0,          'cy': 48.0,          'id': 8,          'locked': false,          'name': 'v1',          'render': true,          'source_cx': 118,          'source_cy': 36,          'type': 'text_gdiplus',          'volume': 1.0,          'x': 199.0,          'y': 846.0        },        {          'cx': 382.0,          'cy': 76.0,          'id': 7,          'locked': false,          'name': 'Color Source 2',          'render': true,          'source_cx': 500,          'source_cy': 100,          'type': 'color_source',          'volume': 1.0,          'x': 1538.0,          'y': 832.0        },        {          'cx': 382.0,          'cy': 76.0,          'id': 6,          'locked': false,          'name': 'Color Source 2',          'render': true,          'source_cx': 500,          'source_cy': 100,          'type': 'color_source',          'volume': 1.0,          'x': 0.0,          'y': 832.0        },        {          'cx': 1920.0,          'cy': 1080.0,          'id': 3,          'locked': true,          'name': 'frame',          'render': true,          'source_cx': 1920,          'source_cy': 1080,          'type': 'image_source',          'volume': 1.0,          'x': 0.0,          'y': 0.0        },        {          'cx': 1049.0,          'cy': 612.0,          'id': 5,          'locked': false,          'name': 'vclass',          'render': true,          'source_cx': 1200,          'source_cy': 700,          'type': 'browser_source',          'volume': 0.68775618076324463,          'x': 921.0,          'y': 217.0        },        {          'cx': 1021.0,          'cy': 603.0,          'id': 4,          'locked': false,          'name': 'Browser',          'render': false,          'source_cx': 1290,          'source_cy': 762,          'type': 'browser_source',          'volume': 0.67712104320526123,          'x': -100.0,          'y': 229.0        },        {          'cx': 0.0,          'cy': 0.0,          'id': 12,          'locked': false,          'name': 'VLC Video Source',          'render': false,          'source_cx': 0,          'source_cy': 0,          'type': 'vlc_source',          'volume': 1.0,          'x': 25.0,          'y': 240.0        },        {          'cx': 1920.0,          'cy': 1080.0,          'id': 2,          'locked': true,          'name': 'back',          'render': true,          'source_cx': 640,          'source_cy': 360,          'type': 'image_source',          'volume': 1.0,          'x': 0.0,          'y': 0.0        }      ]    }  ],  'status': 'ok'}";

            JavaScriptSerializer js = new JavaScriptSerializer();
            scenelist slist = js.Deserialize<scenelist>(t);
            textBox1.Text = js.Serialize(new SceneListNames(slist)).ToString();*/

            //slist[obsName] = js.Deserialize<scenelist>(str);
            //textBox1.Text = exec_comm("/command=GetSceneList");
        }

        private void downloadSceneColl()
        {
            string[] files = new string[] { "frame.png", "textbar.png", "logo.png" , "back1.jpg" };
            string obs_scene_coll_url = "http://207.180.219.104/test/content/";
            WebClient vss = new WebClient();

            string obs_scene_coll_json_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\obs-studio\basic\scenes\";
            string obs_scene_coll_cont_folder = @"c:\obs_content\";

            string jsonfile = obs_scene_coll_json_folder + "main.json";

            if (!File.Exists(jsonfile))
            {
                vss.DownloadFile(new Uri(obs_scene_coll_url + "main.json"), jsonfile);
                terminateOBS();
            }

            try
            {
                if (!Directory.Exists(obs_scene_coll_cont_folder))
                    Directory.CreateDirectory(obs_scene_coll_cont_folder);

                foreach (string f in files)
                {
                    string contfile = obs_scene_coll_cont_folder + f;

                    if (!File.Exists(contfile))
                    {
                        vss.DownloadFile(new Uri(obs_scene_coll_url + f), contfile);
                    }
                }
            }
            catch (Exception ex) { textBox1.Text += Environment.NewLine + ex.Message; }
        }

        private void terminateOBS()
        {
            try
            {
                if (obsPath_txt.Text.Contains("obs"))
                {
                    foreach (Process proc in Process.GetProcessesByName(getFilename(obsPath_txt.Text).Split('.')[0]))
                    {
                        proc.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + " Error OBS Terminatoin : " + ex.Message;
            }
        }

        private string getFilename(string hreflink)
        {
            Uri uri = new Uri(hreflink);

            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            return filename;
        }

        private void OBSserv_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                clientSocket.Close();
            }
            catch (Exception ex)
            {

            }
            Application.Exit();
        }
    }
}
