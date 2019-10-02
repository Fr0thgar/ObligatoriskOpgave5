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

        private static List<Book> books = new List<Book>()
        {
            new Book("Cutting trees with a Herring", "The knights who say Ni", 142,"LKOIJUHYGT123"),
            new Book("Fish Slapping", "Monty Python", 200, "NVHFJENIOA123"),
            new Book("Yelling into the void", "Millennials", 500, "POIUYTREWQ147"),
            new Book("Art of the Butt", "Ninja Sex Party", 999, "KJLLHNFUEN852")
        };

        public ServerWorker()
        {

        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);


            server.Start();
            Console.WriteLine("Go away, I'm working");

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tmpSocket = socket;
                    DoClient(tmpSocket);
                });

            }


        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader bookReader = new StreamReader(socket.GetStream()))
            using (StreamWriter bookWriter = new StreamWriter(socket.GetStream()))
            {

                string str = bookReader.ReadLine();

                bookWriter.WriteLine(str);
                /*
                if (str == "HentAll")
                {

                    string jsonBook = JsonConvert.SerializeObject(books);
                    Console.WriteLine(jsonBook);
                    bookWriter.WriteLine(jsonBook);

                }
                else if (str == "Hent")
                {
//                    Book bookJson = sortList(str);
//                    string jsonSend =
//                        Newtonsoft.Json.JsonConvert.SerializeObject(bookJson);
//                    Console.WriteLine(jsonSend);
//                    bookWriter.WriteLine(jsonSend);
                }
                else if (str == "Gem")
                {
                    string sr = bookReader.ReadLine();
                    Book book = JsonConvert.DeserializeObject<Book>(sr);
                    books.Add(book);
                }

                bookWriter.WriteLine(str);
                bookWriter.Flush();

            */
            }
            socket?.Close();
        }

        public object Book { get; set; }
        public Book sortList(string myList)
        {
            Book myBook = new Book();
            foreach (var book in books)
            {
                if (book.Isbn == myList)
                {
                    myBook = book;
                }
            }

            return myBook;
        }
    }


    internal class JsonConvert
    {
        public static string SerializeObject(object book)
        {
            throw new NotImplementedException();
        }

        public static T DeserializeObject<T>(string sr)
        {
            throw new NotImplementedException();
        }
    }
}

