using Database.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Receiver.Diwine;
using Receiver.Ilmolo;

namespace afalunchrestapi {
    public class Program {
        public static void Main (string[] args) {
             DiwineReceiver diwine = new DiwineReceiver ();
            diwine.ReceiverOfDiwine ();

            IlmoloReceiver ilmolo = new IlmoloReceiver ();
            ilmolo.ReceiverOfIlmolo ();

            System.Console.WriteLine("received all"); 

            CreateHostBuilder (args).Build ().Run ();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
            });
    }
}