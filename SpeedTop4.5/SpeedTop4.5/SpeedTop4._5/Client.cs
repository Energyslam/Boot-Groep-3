using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
namespace SpeedTop4._5
{
    class ClientClass : GameObject
    {

        public static void Connect(String server, String message)
        {
            String[] positionPlayerOne;
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                positionPlayerOne = responseData.Split(' '); //splits the received string at the spaces and saves it in an array

                InformationProject4._5.Information.player1X = float.Parse(positionPlayerOne[0]);
                InformationProject4._5.Information.player1Y = float.Parse(positionPlayerOne[1]);
                InformationProject4._5.Information.spawn = Int32.Parse(positionPlayerOne[2]);
                InformationProject4._5.Information.readyP1 = Int32.Parse(positionPlayerOne[3]); 


                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close(); //the closes are vital. If the stream doesn't close, the program stays in the client class and doesn't run any codes after this.
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                InformationProject4._5.Information.connectionStatus = false; 
            }

            Console.WriteLine("\n Press Enter to continue...");
      //      Console.Read();
        }
    }
}