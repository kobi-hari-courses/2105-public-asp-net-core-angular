using JBClientApis;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientEx
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await CallWithHttpClientBasic();
            await CallWithHttpClientGenerated();
            Console.WriteLine("END.");
        }

        static async Task CallWithHttpClientGenerated()
        {
            HttpClient client = new HttpClient();
            ProductsClient procutsClient = new ProductsClient("https://localhost:44392", client);
            var products = await procutsClient.GetAllAsync();
            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }

        }

        static async Task CallWithHttpClientBasic()
        {
            HttpClient client = new HttpClient();
            var response = await  client.GetAsync("https://localhost:44392/Products");
            var jsonResult = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResult);
        }

    }
}
