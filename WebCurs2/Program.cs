using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebCurs2.Data;

namespace WebCurs2
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            SeedData.EnsureSeedData(scope.ServiceProvider).Wait();
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }

}

