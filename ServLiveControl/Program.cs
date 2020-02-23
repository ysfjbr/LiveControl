using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServLiveControl
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        public static Dictionary<string, string> users = new Dictionary<string, string> {
            { "OBS_OBS1", "mypass" },
            { "OBS_OBS2", "my2pass" },
            { "LC_Yousef", "mypass" },
            { "LC_Ahmed", "my2pass" },

        };

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

                    dataFromClient = getAvaKey(dataFromClient, clientsList);
                    string user = dataFromClient.Split('&')[0];

                    string tuser = user;
                    while (clientsList.Contains(tuser))
                    {
                        tuser = tuser + "*";
                    }

                    clientsList.Add(tuser, clientSocket);

                    broadcast(tuser + " Connected successfully!", user, false);

                    Console.WriteLine(tuser + " Joined ");

                    handleClinet client = new handleClinet();
                    client.startClient(clientSocket, tuser, clientsList);

                    if (!userCanAccess(dataFromClient))
                    {
                        client.stopClient();
                    }


                }
                catch (Exception ex)
                {
                    clientSocket.Close();
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public static bool userCanAccess(string luser)
        {
            string[] user = luser.Split('&');
            return (users[user[0]] == user[1]);
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

        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                try
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

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
                    Console.WriteLine("Error: " + ex);
                }
            }
        }
    }


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
        Thread ctThread;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
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
            doCommand("ch_Conn");
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
                    Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                    //rCount = Convert.ToString(requestCount);
                    doCommand(dataFromClient);

                }
                catch (Exception ex)
                {
                    conn = false;
                    clientsList.Remove(clNo);
                    Program.clientsList.Remove(clNo);
                    doCommand("ch_Conn");
                    //this.clientSocket.Dispose();
                    Console.WriteLine(clNo + " disconncted...");
                    //Console.WriteLine(ex.ToString());
                }
            }
        }

        private void doCommand(string str)
        {
            if (str.StartsWith("ch_Conn"))
            {
                Program.broadcast("CON__" + getclientsListString(clientsList), clNo, false);
            }
            else if (str.StartsWith("OBS"))
            {
                Program.broadcast(str, clNo, false);
            }
            else
            {
                Program.broadcast(str, clNo, false);
            }


        }

        private string getclientsListString(Hashtable table)
        {
            string res = "";
            foreach (DictionaryEntry Item in table)
            {
                res += Item.Key + "^";
            }

            return res;
        }

    }

}

