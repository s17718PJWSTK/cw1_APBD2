using System;
using System.Text.RegularExpressions;

namespace cw1
{
    class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {

            var client = new System.Net.Http.HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl");

            if (result.IsSuccessStatusCode)
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]", RegexOptions.IgnoreCase);

                var matches = regex.Matches(html);

                foreach (var m in matches) Console.WriteLine(m.ToString());
            }



            Console.WriteLine("...");
        }
    }
}
