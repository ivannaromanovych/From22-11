using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2019_11_22ClientConsole
{
    class ValutaPrivat
    {
        public string ccy { get; set; }
        public string base_ccy { get; set; }
        public decimal buy { get; set; }
        public decimal sale { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://localhost:44343/api/values";
            WebClient client = new WebClient();
            string reply = client.DownloadString(url);


            Console.WriteLine(reply);
            var res = JsonConvert.DeserializeObject<List<string>>(reply);
            foreach(var str in res)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }
    }
}
