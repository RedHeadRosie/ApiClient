using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ApiClient
{
    class Program
    {
        // class Item
        // {
        //     public string[] message { get; set; }
        //     public string status { get; set; }
        // }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://dog.ceo/api/breed/australian/list");

            var items = await JsonSerializer.DeserializeAsync<Item>(responseAsStream);


            Console.WriteLine($"The following dogs fall under this category : {items.message}");

        }
    }
}
