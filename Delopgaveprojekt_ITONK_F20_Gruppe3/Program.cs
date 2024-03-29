using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebhostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebhostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });*/
    }
}
