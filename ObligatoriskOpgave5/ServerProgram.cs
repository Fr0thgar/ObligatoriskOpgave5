using System;

namespace ObligatoriskOpgave5
{
    class ServerProgram
    {
        static void Main(string[] args)
        {

            ServerWorker serverWorker = new ServerWorker();
            serverWorker.Start();

            Console.ReadLine();
        }
    }
}
