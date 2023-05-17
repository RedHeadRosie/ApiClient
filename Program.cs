using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ApiClient
{
    class Program
    {
        class Item
        {
            public string type { get; set; }
            public string setup { get; set; }
            public string punchline { get; set; }
            public int id { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/random_joke");

            var items = await JsonSerializer.DeserializeAsync<Item>(responseAsStream);


            Console.WriteLine($"Joke number {items.id} is {items.setup}");
            Console.WriteLine($"{items.punchline}");



        }
    }
}
