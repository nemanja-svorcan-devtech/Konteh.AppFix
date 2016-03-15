using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppFixClient
{
    class Program
    {
        static void Main(string[] args)
        {
	        ConsoleKeyInfo keyPressed = new ConsoleKeyInfo();
	        while (keyPressed.Key != ConsoleKey.Q)
	        {
				Console.WriteLine("\r\nPress R to get result or press Q to exit:");
		        keyPressed = Console.ReadKey();
				if (keyPressed.Key == ConsoleKey.R)
					PrintResult().Wait();
	        }
        }

        static async Task PrintResult()
        {
            string result = null;
            using (var client = new HttpClient())
            {
                var apiAddress = System.Configuration.ConfigurationManager.AppSettings["ApiAddress"];
				HttpResponseMessage response;
				try
				{
					client.BaseAddress = new Uri(apiAddress);
					client.DefaultRequestHeaders.Accept.Clear();
		            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ClientId", System.Configuration.ConfigurationManager.AppSettings["ClientId"]);
		            response = await client.GetAsync("api/kontehchallenge");
	            }
	            catch (Exception e)
	            {
		            Console.WriteLine("\r\n{0}", e.Message);
		            return;
	            }
	            if (response.IsSuccessStatusCode)
	            {
		            result = await response.Content.ReadAsAsync<string>();
	            }
	            else
	            {
					var resultContent = await response.Content.ReadAsStringAsync();
		            result = string.Format("Status: {0}\r\n{1}", response.StatusCode, resultContent);
	            }
            }
            Console.WriteLine("\r\n{0}", result);
        }
    }
}
