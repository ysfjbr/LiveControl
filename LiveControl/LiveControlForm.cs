﻿using System;
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
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;

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
        string[,] recFileslist;
        ListViewItem[] deflvItems;
        

        //string[] inputJson;
        bool Connected = false;

        Dictionary<string, string[]> inputJson = new Dictionary<string, string[]>();
        Dictionary<string, scenelist> slist= new Dictionary<string, scenelist>();
        Dictionary<string, StreamStatus> streamstatus = new Dictionary<string, StreamStatus>();
        Dictionary<string, Obs> obsserver= new Dictionary<string, Obs>();
        List<Control> controlWithTag = new List<Control>();

        public LiveControlForm()
        {
            InitializeComponent();

            foreach (TabPage tp in obs_grp_tabs.TabPages)
            {
                foreach (Control c in tp.Controls)
                {
                    try
                    {
                        if (c.Tag.ToString() != "")
                        {
                            controlWithTag.Add(c);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
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
                try
                {
                    disconnetServer();
                    data_str.Text = "Not Connected!";
                }
                catch (Exception ex1) { }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();

            deflvItems = new ListViewItem[listv_Scenes.Items.Count];

            for (int i = 0; i< listv_Scenes.Items.Count; i++)
            {
                deflvItems[i] = listv_Scenes.Items[i];
            }
            listv_Scenes.Items.Clear();
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
                    Thread.Sleep(100);
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
            else if (str.StartsWith("RFS__"))
            {
                loadRecFiles();
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
                getJson(obsResult[1], obsResult[2], obsResult[3]);
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
            //Thread.Sleep(200);
        }

        void loadRecFiles()
        {
            /*string[] obsResult = command.Split('^');
            int vnum = int.Parse(obsResult[0]);
            int vi = int.Parse(obsResult[1]);

            data_str.Text = obsResult[2] ;
            if (vi == 0)
                recFileslist = new string[vnum,2] ;
            recFileslist[vi,0] = data_str.Text;
            data_str.Text = "";
            try
            {
                recFileslist[vi, 1] = new TimeSpan(0, 0, 0, (int)(double.Parse(obsResult[3].Replace(".","")) /1000000)).ToString();
            }
            catch (Exception ex2) { }

            try
            {
                if (vnum - 1 == vi)
                {
                    grd_Rec_Files.Rows.Clear();

                    for (int i = 0; i < recFileslist.GetLength(0); i++)
                    {
                        
                            grd_Rec_Files.Rows.Add((i + 1).ToString(), recFileslist[i, 0], recFileslist[i, 1]);
                        
                    }
                }
            }
            catch (Exception ex) { textBox1.Text = textBox1.Text + Environment.NewLine + " loadRecFiles Error: " + ex.Message;  }*/
            RecVideo[] rec_videos = RecVideo.FromJson(getSourceRest("Recorded_Videos", "Server"));
            //textBox1.Text = textBox1.Text + Environment.NewLine + " rec :" + rse.Count().ToString();

            grd_Rec_Files.Rows.Clear();
            for (int i = 0; i < rec_videos.GetLength(0); i++)
            {
                string dur = "";
                try
                {
                    dur = new TimeSpan(0, 0, 0, (int)(double.Parse(rec_videos[i].Length.Replace(".", "")) / 1000000)).ToString();

                }
                catch (Exception ex2) { }
                grd_Rec_Files.Rows.Add((i + 1).ToString(), rec_videos[i].File, dur);
            }
        }

        private string getSourceRest(string obj, string ObsName="")
        {
            if (ObsName == "")
            {
                selectedOBS = obs_grid.SelectedRows[0].Cells["OBS_col"].Value.ToString();
                ObsName = selectedOBS;
            }
            string res = sendRest("source/read_one.php", new { sourceName = obj, obsName = ObsName });
            return res;
        }

        private string getOptionRest(string optionKey)
        {
            string res = sendRest("option/read_one.php", new { okey = optionKey });
            return res;
        }

        private string sendRest(string APIurl, object jsonBody)
        {
            RestClient client = new RestClient(@"http://" + ip_txt.Text + @"/");
            RestRequest request = new RestRequest(@"api/" + APIurl, Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddJsonBody(jsonBody);
            //request.AddHeader("authorization", this.Token);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        private void getJson(string obsName , string type, string objName)
        {
            /*if (type == "SceneList")
                getSceneList(obsName);
            else */
            /*if (type == "StreamingStatus")
                getStreamingStatus(obsName);
            else if (type == "SourceSettings")
                getSourceSettings(obsName , objName);*/
            if (type == "StreamingStatus")
                getStreamingStatus(obsName);
            else if (type == "OBSData")
                loadOBSData();
        }


        private bool getSceneList(string obsName = "")
        {
            string str = getSourceRest("SceneList", obsName);
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
            data_str.Text = "";
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

        private bool getStreamingStatus(string obsName = "")
        {
            bool res = false;
            string str = getSourceRest("StreamingStatus", obsName);
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
            data_str.Text = "";
            return res;
        }

        private bool getSourceSettings(string obsName, string objName)
        {
            bool res = false;
            string str = getSourceRest(objName, obsName);
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
                    try
                    {
                        obsserver[s.Split('_')[1]] = Obs.FromJson(getSourceRest("main", s.Split('_')[1]));
                    }catch(Exception ex)
                    {
                        obsserver[s.Split('_')[1]] = null;
                        //sendCommand("loadOBSData", true);
                    }
                    //obsserver[s.Split('_')[1]] = new Obs(s.Split('_')[1], true, false);
                }
            }
            if (obsserver.Count > 0)
            {
                OBSGridUpdate();
                //Thread.Sleep(1000);
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
                        obs_grid.Rows.Add(os.Key,true, os.Value.onAirImg());
                    }
                    obs_grp_tabs.Enabled = obs_grid.Rows.Count > 0;
                    switch_OBS_btn.Enabled = obs_grp_tabs.Enabled;
                    obs_grid.Rows[selectedOBSIndex].Selected = true;
                }
                else
                {
                    obs_grp_tabs.Enabled = false;
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
                clientSocket.Connect(ip_txt.Text, int.Parse(getOptionRest("tcpPort")));
                serverStream = clientSocket.GetStream();

                sendData("LC_" + clientName_txt.Text + "&" + pass_txt.Text, true);
                
                ctThread = new Thread(getMessage);
                ctThread.Start();

                //command_timer.Enabled = false;
                Connected = true;
                data_str.BackColor = Color.Green;
                conn_btn.Text = "Disonnect !";
                saveSettings();
                loadRecFiles();
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
            }
            catch (Exception ex)
            {

            }
            try
            {
                Connected = false;
                
                ctThread.Abort();
                clientSocket.Close();
                serverStream.Close();
                OBSGridUpdate();
            }
            catch(Exception ex3)
            {

            }
        }

        private void saveSettings()
        {
            try
            {
                Properties.Settings.Default["ip"]           = ip_txt.Text;
                Properties.Settings.Default["clientName"]   = clientName_txt.Text;
                Properties.Settings.Default["clientPass"]   = pass_txt.Text;

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
            //Thread.Sleep(300);

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
            vlc1.playlist.add(@"http://"+ ip_txt.Text +":"+ getOptionRest("httpPort_play") + getOptionRest("httpPath_play"));
            vlc1.playlist.play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switchScene(scene_list.SelectedItem.ToString());
        }

        private void switchScene(string sceneName)
        {
            sendCommand(@"SetCurrentScene&"+ sceneName , true);
            //sendCommand("GetSceneList", true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vlc1.playlist.stop();
            vlc1.playlist.items.clear();
            vlc1.playlist.add(@"rtmp://"+ ip_txt.Text + ":" + getOptionRest("rtmpPort") + getOptionRest("final_stream_url"));
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
            List<string> scenes = slist[obsName].getScenes();

            scene_list.DataSource = scenes;
            scene_list.SelectedIndex = scene_list.FindString(slist[obsName].current_scene);

            //********* Load Scenes
            listv_Scenes.Items.Clear();
            foreach (ListViewItem lv in deflvItems)
            {
                if(scenes.Contains(lv.Tag))
                {
                    if ((string)slist[obsName].current_scene == (string)lv.Tag)
                        lv.ForeColor = Color.Red;
                    else
                        lv.ForeColor = Color.Black;

                    listv_Scenes.Items.Add(lv);
                }
            }
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
            Thread.Sleep(200);
            sendCommand("loadOBSData", true);
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
            vlc1.playlist.stop();
        }

        private void switch_OBS_btn_Click(object sender, EventArgs e)
        {
            sendCommand("StopStreaming", false);
            Thread.Sleep(1000);
            sendCommand("StartStreaming", true);
            Thread.Sleep(2000);
            Thread s = new Thread(updateStramStatus);
            //s.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sendCommand("StopStreaming");
        }

        private void obs_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //loadOBSData();
            //sendCommand("loadOBSData", true);
            //loadOBSData();
            selectedOBSIndex = obs_grid.SelectedRows[0].Index;
        }

        private void loadOBSData(string obs="")
        {
            if (obs_grid.SelectedRows[0].Index != -1)
            {
                if (obs == "")
                    obs = obs_grid.SelectedRows[0].Cells["OBS_col"].Value.ToString();

                //obsserver[obs] = Obs.FromJson(getSourceRest("main", obs));
                if (obsserver[obs] != null)
                {
                    List<string> scenes = new List<string>();
                    foreach (SceneOrder s in obsserver[obs].SceneOrder)
                    {
                        scenes.Add(s.Name);
                    }
                    obsserver[obs].CurrentScene = getSourceRest("CurrentScene", obs);
                    listv_Scenes.Items.Clear();
                    foreach (ListViewItem lv in deflvItems)
                    {
                        if (scenes.Contains(lv.Tag))
                        {

                            if (obsserver[obs].CurrentScene == (string)lv.Tag)
                                lv.ForeColor = Color.Red;
                            else
                                lv.ForeColor = Color.Black;

                            listv_Scenes.Items.Add(lv);
                        }
                    }

                    foreach (Source source in obsserver[obs].Sources)
                    {
                        
                        foreach (Control c in controlWithTag)
                        {
                            if (source.Name == c.Tag.ToString())
                            {
                                    SourceSettings ts = Obs.SSFromJson(getSourceRest(source.Name));
                                if (c.Name.Contains("txt_"))
                                {
                                    try
                                    {
                                        c.Text = ts.Text.ToString();
                                    }
                                    catch (Exception ex) { }
                                }
                                else if (c.Name.Contains("url_"))
                                {
                                    try
                                    {
                                        c.Text = ts.Url.ToString();
                                    }
                                    catch (Exception ex) { }
                                }
                                else if (c.Name.Contains("dgv_"))
                                {
                                    try
                                    {
                                        DataGridView dgv = (DataGridView)c;
                                        dgv.Rows.Clear();
                                        int cnt = 1;
                                        foreach (Playlist pl in ts.Playlist)
                                        {
                                            dgv.Rows.Add(cnt.ToString(),pl.Value);
                                            cnt++;
                                        }
                                        
                                        //textBox1.Text += Environment.NewLine + c.GetType();
                                        //textBox1.Text += Environment.NewLine + ts.Playlist.Count.ToString();
                                    }
                                    catch (Exception ex) { }
                                    //textBox1.Text += Environment.NewLine + ts.Playlist.Count.ToString();
                                }
                            }
                        }
                    }
                }
            }
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
            if (source.VersionedId == "text_gdiplus")
            {
                txt_sourcesettings.Text = decodeString(source.Settings.Text);
                if(source.VersionedId == "textbar_text")
                    txt_textbar.Text = decodeString(source.Settings.Text);
                pnl_ChangeText.Visible = true;
            }
            /*
            else if (source.sourceType == "browser_source")
            {
                txt_sourcesettings.Text = decodeString(source.sourceSettings.url);
                pnl_ChangeText.Visible = true;

                if (source.sourceName == "browser1_url")
                {
                    txt_Browser1.Text = decodeString(source.sourceSettings.url);
                }
                if (source.sourceName == "browser2_url")
                {
                    txt_Browser2.Text = decodeString(source.sourceSettings.url);
                }
                if (source.sourceName == "youtube1_url")
                {
                    txt_Youtube1.Text = decodeString(source.sourceSettings.url);
                }
                if (source.sourceName == "youtube2_url")
                {
                    txt_Youtube2.Text = decodeString(source.sourceSettings.url);
                }
                

            }*/
            else
            {
                txt_sourcesettings.Text = "";
                pnl_ChangeText.Visible = false;
            }
            /*
            if (source.sourceType == "vlc_source")
            {
                int n = 1;
                grd_pList.Rows.Clear();
                foreach (Playlist p in source.sourceSettings.playlist)
                {
                    grd_pList.Rows.Add(n.ToString(), p.value);
                    n++;
                }

                if (source.sourceName == "PList")
                {
                    n = 1;
                    dgv_Plist.Rows.Clear();
                    foreach (Playlist p in source.sourceSettings.playlist)
                    {
                        dgv_Plist.Rows.Add(n.ToString(), p.value);
                        n++;
                    }
                }

                pnl_plist.Visible = true;
            }
            else
            {
                grd_pList.Rows.Clear();
                pnl_plist.Visible = false;
            }*/
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
                        //Thread.Sleep(200);
                    }
                        //pl += "{\"hidden\":false,\"selected\":false,\"value\":\"" + row.Cells["clVideo"].Value.ToString() + "\"},"; //"[{\"v\":\"" + row.Cells["clVideo"].Value.ToString() + "\"}],";
                }

                //sendData("OBSPList^" + sname + "^[" + pl + "]");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sendData("StartRec");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sendData("ch_Rec");
            //loadRecFiles();
        }

        private void grd_Rec_Files_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string recPath = @"http://" + ip_txt.Text + getOptionRest("recPath_play");
                string f = grd_Rec_Files.Rows[e.RowIndex].Cells["vFile"].Value.ToString();

                vlc1.playlist.stop();
                vlc1.playlist.items.clear();
                vlc1.playlist.add(recPath+f);
                vlc1.playlist.play();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sendData("StopRec");
        }

        private void grd_pList_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void grd_pList_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void grd_Rec_Files_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grd_Rec_Files.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        string text = (String)
                                grd_Rec_Files.Rows[info.RowIndex].Cells["vFile"].Value;
                        if (text != null)
                        {
                            //Need to put braces here  CHANGE
                            grd_Rec_Files.DoDragDrop(text, DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        private void grd_pList_DragDrop(object sender, DragEventArgs e)
        {
            string recPath = @"http://" + ip_txt.Text + getOptionRest("recPath_play");
            string cellvalue = e.Data.GetData(typeof(string)) as string;
            Point cursorLocation = this.PointToClient(new Point(e.X, e.Y));
            grd_pList.Rows.Add(grd_pList.Rows.Count.ToString(), recPath+cellvalue);
        }

        private void grd_pList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void prevVideo_Click(object sender, EventArgs e)
        {
            if (grd_Rec_Files.SelectedRows[0].Index != -1)
            {
                string recPath = @"http://" + ip_txt.Text + getOptionRest("recPath_play");
                string f = grd_Rec_Files.Rows[grd_Rec_Files.SelectedRows[0].Index].Cells["vFile"].Value.ToString();

                vlc1.playlist.stop();
                vlc1.playlist.items.clear();
                vlc1.playlist.add(recPath + f);
                vlc1.playlist.play();
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listv_Scenes_DoubleClick(object sender, EventArgs e)
        {
            if (listv_Scenes.SelectedItems[0].Tag.ToString() != "")
                switchScene(listv_Scenes.SelectedItems[0].Tag.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //sendData("OBSText^textbar_text^" + encodeString(txt_textbar.Text));
            updateSourceRest(txt_textbar.Tag.ToString(), "{\"text\":\"" + txt_textbar.Text + "\"}");
            sendCommand(@"SetSourceSettings&" + txt_textbar.Tag.ToString(), true);
        }

        private Source getSourcefromOBS(string sourceName, string obs = "")
        {
            if (obs_grid.SelectedRows[0].Index != -1)
            {
                if (obs == "")
                    obs = obs_grid.SelectedRows[0].Cells["OBS_col"].Value.ToString();

                //obsserver[obs] = Obs.FromJson(getSourceRest("main", obs));
                if (obsserver[obs] != null)
                {
                    foreach (Source s in obsserver[obs].Sources)
                    {
                        //textBox1.Text += Environment.NewLine + sourceName + " --- " + s.Name;
                        if (s.Name == sourceName)
                            return s;
                    }
                }
            }

            
            return null;
        }

        private void button18_Click(object sender, EventArgs e)
        {
                updateSourceRest(url_Browser2.Tag.ToString(), "{\"url\":\"" + url_Browser2.Text + "\"}");
                sendCommand(@"SetSourceSettings&" + url_Browser2.Tag.ToString(), true);
            
            //sendData("OBSText^" + txt_Browser2.Text + "^" + encodeString(txt_sourcesettings.Text));
            //Source s = new Source().sourceFromJSON(getSourceRest(txt_Browser2.Tag.ToString()));
            /*if(s == null)
            {
                sendCommand("");
            }*/
            //s.sourceSettings.url = encodeString(txt_sourcesettings.Text);

            //updateSourceRest(txt_Browser2.Tag.ToString(), s.sourceToJSON());
        }

        private void updateSourceRest(string SourceName, string tcontent, string ObsName="")
        {
            if(ObsName=="")
            {
                selectedOBS = obs_grid.SelectedRows[0].Cells["OBS_col"].Value.ToString();
                ObsName = selectedOBS;
            }

            string res = sendRest("source/update.php", new { sourceName = SourceName, content = tcontent, obsName = ObsName });
            textBox1.Text += Environment.NewLine + res;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            updateSourceRest(url_Browser1.Tag.ToString(), "{\"url\":\"" + url_Browser1.Text + "\"}");
            sendCommand(@"SetSourceSettings&" + url_Browser1.Tag.ToString(), true);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            YoutubeVideo yt = new YoutubeVideo();
            yt = yt.Parse(url_Youtube1.Text);
            if(yt == null)
            {
                updateSourceRest(url_Youtube1.Tag.ToString(), "{\"url\":\"" + url_Youtube1.Text + "\"}");
            }
            else
            {
                updateSourceRest(url_Youtube1.Tag.ToString(), "{\"url\":\"" + yt.getEmbedVideo() + "\"}");
            }
            
            sendCommand(@"SetSourceSettings&" + url_Youtube1.Tag.ToString(), true);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            YoutubeVideo yt = new YoutubeVideo();
            yt = yt.Parse(url_Youtube2.Text);
            if (yt == null)
            {
                updateSourceRest(url_Youtube2.Tag.ToString(), "{\"url\":\"" + url_Youtube2.Text + "\"}");
            }
            else
            {
                updateSourceRest(url_Youtube2.Tag.ToString(), "{\"url\":\"" + yt.getEmbedVideo() + "\"}");
            }
            sendCommand(@"SetSourceSettings&" + url_Youtube2.Tag.ToString(), true);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            List<string> plv = new List<string>();
            foreach(DataGridViewRow dgr in dgv_Plist.Rows)
            {
                try
                {
                    plv.Add("{\"hidden\":false,\"selected\":false,\"value\":\"" + dgr.Cells["videoURL"].Value.ToString() + "\"}");
                }catch(Exception ex) { }
            }
            
            updateSourceRest(dgv_Plist.Tag.ToString(), "{\"playlist\":[" + string.Join(",",plv) + "]}");
            sendCommand(@"SetSourceSettings&" + dgv_Plist.Tag.ToString(), true);
        }

        private void LiveControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnetServer();
        }

        private void dgv_Plist_DragDrop(object sender, DragEventArgs e)
        {
            string recPath = @"http://" + ip_txt.Text + getOptionRest("recPath_play");
            string cellvalue = e.Data.GetData(typeof(string)) as string;
            Point cursorLocation = this.PointToClient(new Point(e.X, e.Y));
            dgv_Plist.Rows.Add(dgv_Plist.Rows.Count.ToString(), recPath + cellvalue);
        }

        private void dgv_Plist_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://academy-uk.net/");
        }
    }
}
