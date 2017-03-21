using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class TcpServer : MonoBehaviour {

    Thread TcpThread;

	// Use this for initialization
	void Start () {
        TcpThread = new Thread(() => TheTcpServer());
        TcpThread.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
 
    public void TheTcpServer()
    {
        #pragma warning disable 612, 618
        TcpListener serverSocket = new TcpListener(6789);
        #pragma warning restore 612, 618
        serverSocket.Start();

        TcpClient connectionSocket = serverSocket.AcceptTcpClient();
        //Socket connectionSocket = serverSocket.AcceptSocket();
        Debug.Log("Server activated");

        Stream ns = connectionSocket.GetStream();
        // Stream ns = new NetworkStream(connectionSocket);

        StreamReader sr = new StreamReader(ns);
        StreamWriter sw = new StreamWriter(ns);
        sw.AutoFlush = true; // enable automatic flushing

        
        string message = sr.ReadLine();
        string answer = "";
            while (true)
            {
                Debug.Log("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
               
                //inputHandler
                #region
                if (message.Substring(0,3) == "P1A")
                {
                    MovePlayer1.P1XAimDir = int.Parse(message.Substring(3));
                }
                if(message.Substring(0,3) == "P1B")
                {
                    MovePlayer1.P1YAimDir = int.Parse(message.Substring(3));
                }
                if (message.Substring(0, 3) == "P1C")
                {
                    MovePlayer1.P1ButtonPress = int.Parse(message.Substring(3));
                }
                if (message.Substring(0, 3) == "P2A")
                {
                    MovePlayer2.P2XAimDir = int.Parse(message.Substring(3));
                }
                if (message.Substring(0, 3) == "P2B")
                {
                    MovePlayer2.P2YAimDir = int.Parse(message.Substring(3));
                }
                if (message.Substring(0, 3) == "P2C")
                {
                    MovePlayer2.P2ButtonPress=int.Parse(message.Substring(3));
                }
            //-------keybaord below
                if (message == "p1won")
                {
                    MovePlayer1.p1w = true;
                }
                if (message == "p1woff")
                {
                    MovePlayer1.p1w = false;
                }
                if (message == "p1son")
                {
                    MovePlayer1.p1s = true;
                }
                if (message == "p1soff")
                {
                    MovePlayer1.p1s = false;
                }
                if (message == "p1aon")
                {
                    MovePlayer1.p1a = true;
                }
                if (message == "p1aoff")
                {
                    MovePlayer1.p1a = false;
                }
                if (message == "p1don")
                {
                    MovePlayer1.p1d = true;
                }
                if (message == "p1doff")
                {
                    MovePlayer1.p1d = false;
                }
                //p2
                if (message == "p2won")
                {
                    MovePlayer2.p2w = true;
                }
                if (message == "p2woff")
                {
                    MovePlayer2.p2w = false;
                }
                if (message == "p2son")
                {
                    MovePlayer2.p2s = true;
                }
                if (message == "p2soff")
                {
                    MovePlayer2.p2s = false;
                }
                if (message == "p2aon")
                {
                    MovePlayer2.p2a = true;
                }
                if (message == "p2aoff")
                {
                    MovePlayer2.p2a = false;
                }
                if (message == "p2don")
                {
                    MovePlayer2.p2d = true;
                }
                if (message == "p2doff")
                {
                    MovePlayer2.p2d = false;
                }
            #endregion 

        }



        //ns.Close();
        //connectionSocket.Close();
        //serverSocket.Stop();
        
    }

}
