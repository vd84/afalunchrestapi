using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace afalunchrestapi {
    public class Program {
        public static void Main (string[] args) {
            CreateHostBuilder (args).Build ().Run ();

            //DbRepo dbRepo = new DbRepo ();
            //dbRepo.StartRecievingFromDB ();
        }
         
        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
        }); 
    }
}