using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Database.Repository {
    public class DbRepo {

        public String AllJsonData { get; set; }

        public void StartRecievingFromDB () {

            var factory = new ConnectionFactory () { HostName = "localhost" };
            using (var connection = factory.CreateConnection ())
            using (var channel = connection.CreateModel ()) {
                channel.QueueDeclare (queue: "datafromdatabase",
                    durable : false,
                    exclusive : false,
                    autoDelete : false,
                    arguments : null);
                    
                var consumer = new EventingBasicConsumer (channel);
                consumer.Received += (model, ea) => {
                    var body = ea.Body.ToArray ();
                    var message = Encoding.UTF8.GetString (body);
                    Console.WriteLine (" [x] Received {0}", message);
                    AllJsonData = message;

                };

                channel.BasicConsume (queue: "datafromdatabase",
                    autoAck : true,
                    consumer : consumer);
                
                Console.WriteLine (" Press [enter] to exit.");
                Console.ReadLine ();
            }
        }
    }
}