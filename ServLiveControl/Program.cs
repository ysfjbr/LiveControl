using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServLiveControl
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        public static List<string> usersps = new List<string> { };

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
                    if (!clientsList.Contains(tuser))
                    {
                        if (userCanAccess(dataFromClient))
                        {
                            clientsList.Add(tuser, clientSocket);

                            handleClinet client = new handleClinet();
                            client.startClient(clientSocket, tuser, clientsList);
                            broadcast(tuser + " Connected successfully!", user, false);
                            Console.WriteLine(tuser + " Joined ");
                        }
                        else
                        {
                            broadcast(tuser + " password is wrong!", user, false);
                        }


                    }
                    else
                    {
                        broadcast(tuser + " already logged in!", user, false);
                    }


                }
                catch (Exception ex)
                {
                try
                {
                    clientSocket.Close();
                }
                catch (Exception exx) { }
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
        readPasswords();
        string[] user = luser.Split('&');
        return (usersps.Exists(new Predicate<string> { user[1] });
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
            res += Item.Key + "^";
        }

        return res;
    }

    public static void doCommand(string str, string clNo)
    {
        if (str.StartsWith("ch_Conn"))
        {
            broadcast("CON__" + getclientsListString(clientsList), clNo, false);
        }
        else if (str.StartsWith("OBS"))
        {
            broadcast(str, clNo, false);
        }
        else
        {
            broadcast(str, clNo, false);
        }
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
                //broadcastSocket.Close();
                //clientsList.Remove(Item);
                Console.WriteLine("Error BB: " + ex);
                //Thread.Sleep(500);

            }
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
                Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
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
                //this.clientSocket.Dispose();
                Console.WriteLine(clNo + " disconncted...");
                //Console.WriteLine(ex.ToString());
            }
        }
    }
}
}

