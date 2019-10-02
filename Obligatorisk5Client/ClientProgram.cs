using System;

namespace Obligatorisk5Client
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            ClientWorker clientWorker = new ClientWorker();
            clientWorker.Start();
            Console.ReadLine();
        }
    }
}
