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

       
    }
}

