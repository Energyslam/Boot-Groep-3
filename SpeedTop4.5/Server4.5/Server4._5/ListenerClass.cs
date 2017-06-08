
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server4._5
{
    public class ListenerClass
    {
        public static void Listening()
        {
            
            string[] positions;
            

            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                //Client now uses a toString to get local ip adress and uses this to connect
              //IPAddress localAddr = IPAddress.Parse(GetLocalIPAddress()); //host on your current ipadres
                IPAddress localAddr = IPAddress.Parse("127.0.0.1"); //for local host testing

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    // includes local adress when waiting for connection
                    Console.Write("Waiting for a connection... Local adress = " + GetLocalIPAddress());

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        positions = data.Split(' '); //splits the string on a space and saves these in an array
                        InformationProject4._5.Information.player2X = float.Parse(positions[0]);
                        InformationProject4._5.Information.player2Y = float.Parse(positions[1]);
                        InformationProject4._5.Information.readyP2 = Int32.Parse(positions[2]);             
                        InformationProject4._5.Information.skinp2 = Int32.Parse(positions[3]);

                        // Process the data sent by the client.
                        // data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(InformationProject4._5.Information.messagePlayerOne);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", InformationProject4._5.Information.messagePlayerOne); //sends a message back to the client after a message has been received
                    }

                    // Shutdown and end connection
                    client.Close(); 
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
        // toString voor local ip adres
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}