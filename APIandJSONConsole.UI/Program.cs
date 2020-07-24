using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIandJSONConsole.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            

            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var ronResponse = client.GetStringAsync(ronURL).Result;
               

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                
                Console.WriteLine($"Kanye Says: {kanyeQuote}");
                Console.WriteLine();
                Console.ReadLine();
                Console.WriteLine($"Ron Says: {ronQuote}");
                Console.WriteLine();
                Console.ReadLine();
               
            }
        }
    }
}
