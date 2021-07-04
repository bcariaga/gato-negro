using System.Reflection;
using Bootstrap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => 
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSetting(
                            WebHostDefaults.ApplicationKey, 
                            typeof(Program).GetTypeInfo().Assembly.FullName));
    }
}
