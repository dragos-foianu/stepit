using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Web.Helpers;

namespace WebRequestApp
{
    class Program
    {
        public int bla;
        static void Main(string[] args)
        {
            var currency = "USD";
            var response = WebRequest.Create("http://api.fixer.io/latest?base=" + currency).GetResponse();
            var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            dynamic data = System.Web.Helpers.Json.Decode(jsonString);

            var baseCurrency = data.@base;
            var date = data.date;
            var baseToEUR = data.rates.EUR;
            var baseToRON = data.rates.RON;

            Console.WriteLine("base = " + baseCurrency);
            Console.WriteLine("date = " + date);
            Console.WriteLine("baseToEUR = " + baseToEUR);
            Console.WriteLine("baseToRON = " + baseToRON);
            Console.WriteLine();

            int x = 1234;
            Console.WriteLine(x + baseCurrency + " = " + x * baseToRON + "RON");
        }
    }
}
