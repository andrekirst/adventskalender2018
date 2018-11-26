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
            await new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(contentRoot: Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build()
                .RunAsync();
        }
    }
}
