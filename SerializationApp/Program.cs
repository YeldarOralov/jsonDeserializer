using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace SerializationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                FullName = "Denis"
            };
          
            string json = JsonConvert.SerializeObject(person);
            Person result = JsonConvert.DeserializeObject<Person>(json);




            WebClient client = new WebClient();
            var jsonChar = client.DownloadString("http://hp-api.herokuapp.com/api/characters");
            var rez = JsonConvert.DeserializeObject<RootObject[]>(jsonChar);

            
            jsonChar = client.DownloadString("http://hp-api.herokuapp.com/api/characters/students");
            rez = JsonConvert.DeserializeObject<RootObject[]>(jsonChar);

            jsonChar = client.DownloadString("http://hp-api.herokuapp.com/api/characters/staff");
            rez = JsonConvert.DeserializeObject<RootObject[]>(jsonChar);

            jsonChar = client.DownloadString("http://hp-api.herokuapp.com/api/characters/house/gryffindor");
            rez = JsonConvert.DeserializeObject<RootObject[]>(jsonChar);

            Console.WriteLine("Файл загружен");
            Console.Read();
        }
    }
}
