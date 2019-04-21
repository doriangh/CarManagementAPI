using CarManagement.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CarManagementAPI___New
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5000");

        public void CreateDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
