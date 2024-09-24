using System;
using System.Net.Http;

namespace WeatherApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = "1";
            while (choice == "1")
            {
                Console.WriteLine("Įveskite miestą: ");
                string city = Console.ReadLine();
                using(var client = new HttpClient())
                {
                    var endpoint = new Uri("https://api.meteo.lt/v1/places/" + city + "/forecasts");
                    //var endpoint = new Uri("https://api.meteo.lt/v1/places/" + city + "/forecasts/long-term");
                    var response = client.GetAsync(endpoint).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(result);
                    }
                    else Console.WriteLine("Klaida. Bandykite dar kartą");
                    Console.WriteLine("Jei norite tęsti programą spauskite 1");
                    choice = Console.ReadLine();
                    if (choice != "1")
                    {
                        Console.WriteLine("Viso gero!");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}