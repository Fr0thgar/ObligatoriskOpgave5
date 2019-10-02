using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.Threading.Tasks;
using Library;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace ObligatoriskOpgave5
{
    public class ServerWorker
    {
        public ServerWorker()
        {

        }

        private static List<Book> books = new List<Book>()
        {
            new Book("Cutting trees with a Herring", "The knights who say Ni", 142,"LKOIJUHYGT123"),
            new Book("Fish Slapping", "Monty Python", 200, "NVHFJENIOA123"),
            new Book("Yelling into the void", "Millennials", 500, "POIUYTREWQ147"),
            new Book("Art of the Butt", "Ninja Sex Party", 999, "KJLLHNFUEN852")
        };

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();
            Console.WriteLine("I'm Working I hope");

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();

                Task.Run(()
                    =>
                {
                    TcpClient tmpsocket = socket;
                    DoClient(tmpsocket);
                });
            }

        }

        private void DoClient(TcpClient socket)
        {

            using (StreamReader bookReader =
                new StreamReader(socket.GetStream()))
            using (StreamWriter bookWriter = new StreamWriter(socket.GetStream()))
            {
                while (true)
                {

                    string str = bookReader.ReadLine();

                    switch (str)
                    {
                        case "HentAlle":
                            string s = bookReader.ReadLine();
                            bookWriter.WriteLine(HentAlle());
                            bookWriter.Flush();
                            break;
                        case "Hent":
                            string isbnInput = bookReader.ReadLine();
                            string output = Hent(isbnInput);
                            bookWriter.WriteLine(output);
                            bookWriter.Flush();
                            break;
                        case "Gem":
                            string JsonInput = bookReader.ReadLine();
                            Gem(JsonInput);
                            break;
                    }

                   
                    if (str == "end" || str == "End")
                    {
                        break;
                    }
                }
            }
            socket?.Close();
        }

        private string HentAlle()
        {
            return JsonConvert.SerializeObject(books);
        }

        private string Hent(string isbn)
        {
            return JsonConvert.SerializeObject(books.Find(b => b.Isbn == isbn));
        }

        private void Gem(string JBook)
        {
            Book b = JsonConvert.DeserializeObject<Book>(JBook);
            books.Add(b);
        }
    }
}

