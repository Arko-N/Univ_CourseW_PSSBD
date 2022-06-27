using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Server
    {
        private static int timeout = 5 * 60 * 1000; // todo [:] RECEIVE TIMEOUT [ sec * 1000 ]
        private static int max_count = 5;           // todo [:] MAX USERS COUNT
        private static int counter = 0;
        private static void DecreaseCounter() { counter--; }

        private const int port = 8888;
        private static TcpListener listener;

        private static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("====================================\n\n========== SERVER STARTED ==========\n\n====================================\n");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    client.ReceiveTimeout = timeout;
                    counter++;
                    Client_unit clientObject = new Client_unit(client, counter, max_count);
                    clientObject.onDistruct += DecreaseCounter;

                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (listener != null)
                    listener.Stop();
                Console.WriteLine("Для завершения жми \"ENTER\"");
                Console.ReadLine();
            }
        }
    }
}