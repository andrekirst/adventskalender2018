using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Adventskalender2018
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(contentRoot: Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build()
                .RunAsync();
        }
    }
}
