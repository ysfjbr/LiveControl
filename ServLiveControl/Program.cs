using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace ServLiveControl
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        public static List<string> usersps = new List<string> { };

        public static string commandFile, commandArgs;
        public static Thread runCommThread;
        public static string recPath = "/var/www/html/test/content/";

        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8123);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Stream Server Started ....");
            counter = 0;
            while ((true))
            {
                counter += 1;
                try
                {
                    clientSocket = serverSocket.AcceptTcpClient();

                    byte[] bytesFrom = new byte[10025];
                    string dataFromClient = null;

                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)bytesFrom.Length);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    //dataFromClient = getAvaKey(dataFromClient, clientsList);
                    string user = dataFromClient.Split('&')[0];

                    string tuser = user;

                    clientsList.Add(tuser, clientSocket);
                    handleClinet client = new handleClinet();
                    client.startClient(clientSocket, tuser, clientsList);

                    string errmsg = userCanAccess(dataFromClient);

                    if (errmsg == "0")
                    {

                        broadcast(tuser + " Connected successfully!", user, false);
                        Console.WriteLine(tuser + " Joined ");
                    }
                    else
                    {
                        broadcast(errmsg, user, false);
                        client.stopClient();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("broadcast Error: " + ex.Message);
                    try
                    {
                        clientSocket.Close();
                    }
                    catch (Exception exx) { Console.WriteLine("clientSocket Error: " + ex.Message); }
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public static string userCanAccess(string luser)
        {
            string errmsg = "0";
            readPasswords();
            string[] user = luser.Split('&');
            if (clientsList.Contains(luser))
                errmsg = luser + " already logged in!";
            else if (!usersps.Contains(user[1]))
                errmsg = "Your password is wrong!";

            return errmsg;
        }

        public static void ffmpegRecStream()
        {
            commandFile = "ffmpeg";
            //rtmp://207.180.219.104:1936/stream/final
            string ftime = DateTime.Now.ToString("yyyyMMdd_Hmmss");

            commandArgs = "-y -i rtmp://207.180.219.104:1936/stream/final -vcodec copy -acodec copy /var/www/html/test/content/"+ ftime + ".mp4";
            runCommThread = new Thread(startRecCommand);
            runCommThread.Start();
        }

        public static void startRecCommand()
        {
            Process.Start(commandFile, commandArgs);
        }
        public static string runCommand(string command, string args)
        {
            string output;
            using (Process process = new Process())
            {
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = args;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                output = reader.ReadToEnd();

                // Write the redirected output to this application's window.
                Console.WriteLine(output);

                process.WaitForExit();
            }

            return output;
        }



        public static string getAvaKey(string key, Hashtable table)
        {
            string res = key;
            while (table.ContainsKey(res))
            {
                res = res + "*";
            }

            return res;
        }

        public static void readPasswords()
        {
            try
            {
                foreach (string line in File.ReadLines("/var/www/netcoreapp3.1/ps.txt", Encoding.UTF8))
                {
                    usersps.Add(line);
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error: " + ex.Message); }
        }

        public static string getclientsListString(Hashtable table)
        {
            string res = "";
            foreach (DictionaryEntry Item in table)
            {
                res += Item.Key + "%";
            }

            return res;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public static void doCommand(string str, string clNo)
        {
            if (str.StartsWith("ch_Conn"))
            {
                broadcast("CON__" + getclientsListString(clientsList), clNo, false);
            }
            else if(str.StartsWith("ch_Rec"))
            {
                get_recorded_files();
            }
            else if (str.StartsWith("OBS"))
            {
                broadcast(str, clNo, false);
            }
            else if (str.StartsWith("StartRec"))
            {
                ffmpegRecStream();
            }
            else if (str.StartsWith("StopRec"))
            {
                Process.Start("pkill", "ffmpeg");
                get_recorded_files();
                runCommThread.Abort();
            }
            else
            {
                broadcast(str, clNo, false);
            }
            //Thread.Sleep(200);
        }

        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket = (TcpClient)Item.Value;
                try
                {
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;
                    //Console.WriteLine("ConnSTATUS : " + broadcastSocket.Connected.ToString());
                    if (flag == true)
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                    }
                    else
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(msg);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                }
                catch (Exception ex)
                {
                    try
                    {
                        broadcastSocket.Close();
                    }
                    catch (Exception ex1) { }
                    clientsList.Remove(Item);
                    Console.WriteLine("Error BB: " + ex);
                    //Thread.Sleep(500);

                }
            }

        }

        public static void get_recorded_files()
        {
            List<string> fs = new List<string>();

            DirectoryInfo info = new DirectoryInfo(recPath);
            FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                if (file.Extension == ".mp4")
                {
                    fs.Add(file.FullName);
                }
            }
            int i = 0;
            foreach(string f in fs)
            {
                string args = @" -v error -show_entries format=duration \-of default=noprint_wrappers=1:nokey=1 " + f;
                string dur = runCommand("ffprobe", args);
                broadcast("RFS__"+ fs.Count+"^" + i.ToString() + "^" +  Path.GetFileName(f) + "^" + dur, "Server", false);
                
                Thread.Sleep(100);
                i++;
            }
        }
    }


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        //Hashtable clientsList;
        Thread ctThread;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            //this.clientsList = cList;
            ctThread = new Thread(doWork);
            ctThread.Start();
        }

        public void stopClient()
        {
            this.clientSocket.Close();
            ctThread.Abort();
            Console.WriteLine("client - " + clNo + " STOPPED ");
        }

        private void doWork()
        {
            //int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            //string rCount = null;
            //requestCount = 0;
            Program.doCommand("ch_Conn", clNo);
            bool conn = true;
            while (conn)
            {
                try
                {
                    //requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)bytesFrom.Length);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("From client - " + clNo + " : " + dataFromClient + networkStream.DataAvailable.ToString() + " - " + clientSocket.Connected.ToString());
                    //rCount = Convert.ToString(requestCount);
                    //doCommand(dataFromClient);
                    Program.doCommand(dataFromClient, clNo);

                }
                catch (Exception ex)
                {
                    conn = false;
                    //clientsList.Remove(clNo);
                    Program.clientsList.Remove(clNo);
                    //doCommand("ch_Conn");
                    //Program.doCommand("ch_Conn", clNo);
                    this.clientSocket.Close();
                    Console.WriteLine(clNo + " disconncted...");
                    //Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}

