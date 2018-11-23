using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;

namespace Adventskalender2018
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //CreateWebHostBuilder(args: args).Build().Run();
            await new WebHostBuilder()
                .UseKestrel()
                //.ConfigureServices(configureServices: services => services.AddAutofac())
                .UseContentRoot(contentRoot: Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .Build()
                .RunAsync();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args: args)
        //        .UseStartup<Startup>();
    }
}
