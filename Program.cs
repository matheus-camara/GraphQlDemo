using Demo.Graph;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}