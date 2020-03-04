using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace LiveControl
{
    public partial class LiveControlForm : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        Thread ctThread;
        string selectedOBS = "";
        int selectedOBSIndex = -1;
        
        //string[] inputJson;
        bool Connected = false;

        Dictionary<string, string[]> inputJson = new Dictionary<string, string[]>();
        Dictionary<string, scenelist> slist= new Dictionary<string, scenelist>();
        Dictionary<string, StreamStatus> streamstatus = new Dictionary<string, StreamStatus>();
        Dictionary<string, OBSserver> obsserver= new Dictionary<string, OBSserver>();

        public LiveControlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendData(textBox2.Text);
        }

        private void sendData(string Str, bool toConnect = false)
        {
            try
            {
                if (Connected || toConnect)
                {
                    byte[] outStream = Encoding.ASCII.GetBytes(Str + "$");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                }

                else
                {
                    data_str.Text = "Not Connected!";
                }
            }
            catch(Exception ex)
            {
                disconnetServer();
                data_str.Text = "Not Connected!";
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
        }


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
            }
            catch (Exception ex)
            {
                disconnetServer();
                try
                {
                    listBox1.Items.Clear();
                    textBox1.Text = textBox1.Text + Environment.NewLine + " Error: " + ex.Message;
                }
                catch (Exception ex2)
                {

                }
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                doCommand(readData);
        }

        private void doCommand(string str)
        {
            //textBox1.Text += Environment.NewLine + str;
            if (str.StartsWith("CON__"))
            {
                getDevices(str);
            }
            else if (str.StartsWith("OBSC_"))
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> obs command " + str.Substring(5);
            }
            else if (str.StartsWith("OBS^"))
            {
                /*commandThread.Add(new Thread(() => getOBSOutput(str.Split('^'))));//  new Thread(new ParameterizedThreadStart(getOBSOutput)));
                if(!inputJson.ContainsKey(str.Split('^')[2]))
                    inputJson[str.Split('^')[2]] = new string[int.Parse(str.Split('^')[4])];
                commandThread[commandThread.Count - 1].Start();*/
                /*string[] obsResult = str.Split('^');
                Thread commandThread = new Thread(() => getJson(obsResult[3], obsResult[2], obsResult[1]));
                commandThread.Start(); */
                string[] obsResult = str.Split('^');
                getJson(obsResult[3], obsResult[2], obsResult[1]);
                textBox1.Text = textBox1.Text + Environment.NewLine + obsResult[1] + " >> " + obsResult[3];
            }
            else
            {
                data_str.Text = str;
                /*if (data_str.Text == "")
                {
                    data_str.Text = "Connection Failed! check your name and password";
                    textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + data_str.Text;
                    disconnetServer();
                }*/
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + data_str.Text;
            }
        }

        private void getOBSOutput(string[] obsResult)
        {
            richTextBox1.Text = obsResult[3];
            getJson(obsResult[3], obsResult[2], obsResult[1]);
            /*inputJson[obsResult[2]][int.Parse(obsResult[3])] = obsResult[5];

            bool compCommand = true;
            string cc = "";

            for ( int i = 0;i <  int.Parse(obsResult[4]); i++ )
            {
                string s = inputJson[obsResult[2]][i];
                
                if (s == null || s == "")
                    compCommand = false;
                cc += s;
                
            }
            
            if (compCommand)
                richTextBox1.Text = " >>> " + cc ;*/

            //getJson(cc, obsResult[1]);

            //richTextBox1.AppendText(obsResult[2]);
            //MessageBox.Show(obsResult[2]);
            //getJson(obsResult[2], obsResult[1]);
            //textBox1.Text += " >>HI>>>" + obsResult[2] + "<<";
            //textBox1.Text += " >>inputJson>>>" + inputJson + "<<";
            /*if (obsResult[2].StartsWith("%START%"))
            {
                 richTextBox1.Text = obsResult[2].Substring(7);
            }
            else
            {
                richTextBox1.AppendText(obsResult[2]); 
            }
            if (obsResult[2].Contains("%END%"))
            {
                richTextBox1.AppendText(obsResult[2]);

                getJson(richTextBox1.Text, obsResult[1]);
            }*/

            //textBox1.Text = " >333>>>> " + Environment.NewLine + inputJson + Environment.NewLine + " ********* " + Environment.NewLine;
        }

        private void getJson(string str,string type, string obsName)
        {
            if (type == "SceneList")
                getSceneList(str, obsName);
            else if (type == "StreamingStatus")
                getStreamingStatus(str, obsName);
            else if (type == "SourceSettings")
                getSourceSettings(str, obsName);
        }

        private bool getSceneList(string str, string obsName = "")
        {

            data_str.Text = correctJSON(str);

            bool res = false;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                slist[obsName] = js.Deserialize<scenelist>(data_str.Text);
                loadScene(selectedOBS);
                
                res = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                res = false;
            }
            //data_str.Text = "";
            return res;
        }

        private string correctJSON(string str)
        {
            str = str.Replace("current-scene", "current_scene");
            str = str.Replace("preview-only", "preview_only");
            str = str.Replace("message-id", "message_id");
            str = str.Replace("recording-paused", "recording_paused");
            str = str.Replace("stream-timecode", "stream_timecode");
            str = str.Replace("rec-timecode", "rec_timecode");
            str = str.Substring(0, str.LastIndexOf("}") + 1);

            return str;
        }

        private bool getStreamingStatus(string str, string obsName = "")
        {
            bool res = false;
            data_str.Text = correctJSON(str);
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                streamstatus[obsName] = js.Deserialize<StreamStatus>(data_str.Text);
                obsserver[obsName].OnAir = streamstatus[obsName].streaming;

                OBSGridUpdate();

                res = true;
            }
            catch (Exception ex)
            {
                
                res = false;
            }
            //data_str.Text = "";
            return res;
        }

        private bool getSourceSettings(string str, string obsName = "")
        {
            bool res = false;
            data_str.Text = correctJSON(str);
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Source source = js.Deserialize<Source>(data_str.Text);
                showSourceSettings(source);
                
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            data_str.Text = "";
            return res;
        }

        private void getDevices(string command)
        {
            listBox1.Items.Clear();
            obsserver.Clear();
            foreach (string s in command.Substring(5).Split('%'))
            {
                listBox1.Items.Add(s);
                if(s.StartsWith("OBS_"))
                {
                    obsserver[s.Split('_')[1]] = new OBSserver(s.Split('_')[1], true, false);
                }
            }
            if (obsserver.Count > 0)
            {
                OBSGridUpdate();
                Thread.Sleep(1000);
                sendCommand("GetStreamingStatus");
            }
            else
                obs_grid.Rows.Clear();

        }

        private void OBSGridUpdate()
        {
            try
            {
                obs_grid.Rows.Clear();
                if (Connected)
                {
                    
                    foreach (var os in obsserver)
                    {
                        obs_grid.Rows.Add(os.Value.getRow());
                    }
                    obs_grp.Enabled = obs_grid.Rows.Count > 0;
                    switch_OBS_btn.Enabled = obs_grp.Enabled;
                    obs_grid.Rows[selectedOBSIndex].Selected = true;
                }
                else
                {
                    obs_grp.Enabled = false;
                    switch_OBS_btn.Enabled = false;
                }
            }
            catch (Exception ex) { }
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
            readData = "Conecting to Stream Server ...";
            msg();
            try
            {
                clientSocket.Close();
                clientSocket = new TcpClient();
                clientSocket.Connect(ip_txt.Text, int.Parse(port_txt.Text));
                serverStream = clientSocket.GetStream();

                sendData("LC_" + clientName_txt.Text + "&" + pass_txt.Text, true);
                
                ctThread = new Thread(getMessage);
                ctThread.Start();

                //command_timer.Enabled = false;
                Connected = true;
                data_str.BackColor = Color.Green;
                conn_btn.Text = "Disonnect !";
                saveSettings();
            }
            catch (Exception ex)
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + ex.Message;
            }
        }

        private void disconnetServer()
        {
            try
            {
                listBox1.Items.Clear();
                obs_grid.Rows.Clear();
            }
            catch (Exception ex2){}

            try
            {
                conn_btn.Text = "Connect !";
                data_str.BackColor = Color.Gray;
                Connected = false;
                
                ctThread.Abort();
                clientSocket.Close();
                serverStream.Close();
                OBSGridUpdate();
            }
            catch(Exception ex)
            {

            }
        }

        private void saveSettings()
        {
            try
            {
                Properties.Settings.Default["ip"] = ip_txt.Text;
                Properties.Settings.Default["port"] = port_txt.Text;
                Properties.Settings.Default["clientName"] = clientName_txt.Text;
                Properties.Settings.Default["clientPass"] = pass_txt.Text;

                Properties.Settings.Default.Save();
            }catch(Exception ex)
            {

            }
        }

        private void loadSettings()
        {
            try
            {
                if (Properties.Settings.Default["ip"].ToString() != "")
                {
                    ip_txt.Text     = Properties.Settings.Default["ip"].ToString();
                    port_txt.Text   = Properties.Settings.Default["port"].ToString();
                    clientName_txt.Text = Properties.Settings.Default["clientName"].ToString();
                    pass_txt.Text   = Properties.Settings.Default["clientPass"].ToString();
                }
            }catch(Exception ex)
            {

            }
        }

        private void sendCommand(string command, bool onlySelectedOBS = false)
        {
            try
            {
                if (onlySelectedOBS)
                {
                    selectedOBS = obs_grid.SelectedRows[0].Cells["OBS_col"].Value.ToString();
                    sendData("OBS^" + selectedOBS + "^TOOBS^" + command);
                }
                else
                {
                    sendData("OBSC_" + command);
                }
            }
            catch (Exception ex) { disconnetServer(); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendCommand("GetSceneList",true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*sendCommand("startstream", true);
            Thread.Sleep(3000);
            Thread s = new Thread(updateStramStatus);
            s.Start();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* sendCommand("stopstream", true);
            Thread.Sleep(3000);
            Thread s = new Thread(updateStramStatus);
            s.Start();*/
        }

        private void updateStramStatus()
        {
            sendCommand("GetStreamingStatus");
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            vlc1.playlist.stop();
            vlc1.playlist.items.clear();
            vlc1.playlist.add(@"http://207.180.219.104:7171/hls/final.m3u8");
            vlc1.playlist.play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switchScene(scene_list.SelectedItem.ToString());
        }

        private void switchScene(string sceneName)
        {
            sendCommand(@"SetCurrentScene&"+ sceneName , true);
            Thread.Sleep(500);
            sendCommand("GetSceneList", true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vlc1.playlist.stop();
            vlc1.playlist.items.clear();
            vlc1.playlist.add(@"rtmp://207.180.219.104:1936/stream/final");
            vlc1.playlist.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendData("ch_Conn");
        }
        

        private void scene_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (scene_list.SelectedIndex != -1)
                    source_list.DataSource = slist[selectedOBS].getSources((scene_list.SelectedItem.ToString()));
            }
            catch (Exception ex) { }
        }

        private void scene_list_DoubleClick(object sender, EventArgs e)
        {
            if (scene_list.SelectedIndex != -1)
                switchScene(scene_list.SelectedItem.ToString());
        }

        private void obs_grid_SelectionChanged(object sender, EventArgs e)
        {
            //selectedOBS = obs_grid.SelectedRows[0].Cells["OBS_col"].Value.ToString();
            //sendData("OBSC_/command=GetSceneList");
        }

        private void loadScene(string obsName)
        {
            scene_list.DataSource = slist[obsName].getScenes();
            scene_list.SelectedIndex = scene_list.FindString(slist[obsName].current_scene);
        }

        private void scene_list_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            try
            {
                if (scene_list.Items[e.Index].ToString() == slist[selectedOBS].current_scene)
                {
                    e.Graphics.DrawString(scene_list.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, e.Bounds);
                }
                else
                {
                    e.Graphics.DrawString(scene_list.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, e.Bounds);
                }
            }
            catch(Exception ex)
            {
                //e.Graphics.DrawString(scene_list.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, e.Bounds);
            }
            
            e.DrawFocusRectangle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //sendData("OBSC_/command=GetStreamingStatus");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            OBSGridUpdate();
            sendCommand("GetStreamingStatus", false);
        }

        private void LiveControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconnetServer();
            Application.Exit();
        }

        private void tim_loadsc_Tick(object sender, EventArgs e)
        {
            sendCommand("GetSceneList", false);
            tim_loadsc.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sendData("StopRec");
            vlc1.playlist.stop();
        }

        private void switch_OBS_btn_Click(object sender, EventArgs e)
        {
            sendCommand("StopStreaming", false);
            Thread.Sleep(1000);
            sendCommand("StartStreaming", true);
            Thread.Sleep(2000);
            Thread s = new Thread(updateStramStatus);
            s.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sendCommand("StopStreaming");
        }

        private void obs_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sendCommand("GetSceneList", true);
            selectedOBSIndex = obs_grid.SelectedRows[0].Index;
        }

        private void obs_grp_Enter(object sender, EventArgs e)
        {
            /*
            to record ffmpeg.exe - y - i rtmp://207.180.219.104:1936/stream/final /var/www/html/test/content/rec1.mp4
            to stream ffmpeg -re - i /var/www/html/test/content/rec1.mp4 - c copy - f flv rtmp://207.180.219.104:1936/stream/v1
            */
        }

        private void source_list_DoubleClick(object sender, EventArgs e)
        {
            if (source_list.SelectedIndex != -1)
                getSourceSettings(source_list.SelectedItem.ToString());
        }

        private void getSourceSettings(string sourceName)
        {
            sendCommand("GetSourceSettings&" + sourceName, true);
        }

        private void showSourceSettings(Source source)
        {
            if (source.sourceType == "text_gdiplus")
            {
                txt_sourcesettings.Text = decodeString(source.sourceSettings.text);
                pnl_ChangeText.Visible = true;
            }
            else if (source.sourceType == "browser_source")
            {
                txt_sourcesettings.Text = decodeString(source.sourceSettings.url);
                pnl_ChangeText.Visible = true;
            }
            else
            {
                txt_sourcesettings.Text = "";
                pnl_ChangeText.Visible = false;
            }

            if (source.sourceType == "vlc_source")
            {
                int n = 1;
                grd_pList.Rows.Clear();
                foreach (Playlist p in source.sourceSettings.playlist)
                {
                    grd_pList.Rows.Add(n.ToString(), p.value);
                    n++;
                }
                
                pnl_plist.Visible = true;
            }
            else
            {
                grd_pList.Rows.Clear();
                pnl_plist.Visible = false;
            }
        }

        private void source_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (source_list.SelectedIndex != -1)
                getSourceSettings(source_list.SelectedItem.ToString());
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (source_list.SelectedIndex != -1)
            {
                string sname = source_list.SelectedItem.ToString();
                sendData("OBSText^"+sname +"^"+ encodeString(txt_sourcesettings.Text));
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (source_list.SelectedIndex != -1)
            {
                string sname = source_list.SelectedItem.ToString();
                string pl = "";
                int i = 0;
                foreach(DataGridViewRow row in grd_pList.Rows)
                {
                    if (row.Cells["clVideo"].Value != null)
                    {
                        sendData("OBSPList^" + sname + "^" + (grd_pList.Rows.Count-1).ToString() + "^" + i.ToString() + "^" + encodeString(row.Cells["clVideo"].Value.ToString()));
                        i++;
                        Thread.Sleep(200);
                    }
                        //pl += "{\"hidden\":false,\"selected\":false,\"value\":\"" + row.Cells["clVideo"].Value.ToString() + "\"},"; //"[{\"v\":\"" + row.Cells["clVideo"].Value.ToString() + "\"}],";
                }

                //sendData("OBSPList^" + sname + "^[" + pl + "]");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sendData("StartRec");
            /*YoutubeVideo yt = new YoutubeVideo().Parse(textBox2.Text);
     
            if (yt != null)
                MessageBox.Show(yt.getDuration().ToString());
            else
                MessageBox.Show("Not Youtube");
            */
        }
    }
}
