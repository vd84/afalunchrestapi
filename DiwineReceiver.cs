using System;
using System.Collections.Generic;
using System.Text;
using database.manager;
using Dbitems.MenuItem;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receiver.Diwine {
    class DiwineReceiver {
        public void ReceiverOfDiwine () {

            DbManager dbManager = new DbManager ();
            
            string jsonAllDays = "";
            var factory = new ConnectionFactory () { HostName = "172.21.40.149", Port=5672, UserName="guest", Password="guest"};

            using (var connection = factory.CreateConnection ())
            using (var channel = connection.CreateModel ()) {
                channel.QueueDeclare (queue: "insertdiwinemenu",
                    durable : false,
                    exclusive : false,
                    autoDelete : false,
                    arguments : null);
                    

                var consumer = new EventingBasicConsumer (channel);
                consumer.Received += (model, ea) => {
                    var body = ea.Body.ToArray ();
                    var message = Encoding.UTF8.GetString (body);
                    //Console.WriteLine (" [x] Received {0}", message);
                    jsonAllDays = message;

                };
                channel.BasicConsume (queue: "insertdiwinemenu",
                    autoAck : true,
                    consumer : consumer);

                Console.WriteLine (" Press [enter] to exit.");
                Console.ReadLine ();
            }

            //Receive the json obj
            Dictionary<int, List<MenuItem>> menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, List<MenuItem>>> (jsonAllDays);
            //Print json obj
            foreach (var item in menuItems) {
                System.Console.WriteLine(item.Key);
                foreach(var lunchitem in item.Value){
                    System.Console.WriteLine(lunchitem.Title);
                    dbManager.INSERTINTOMENU(item.Key, lunchitem.Title, lunchitem.Ingredients, lunchitem.Price, lunchitem.IdOfRestaurant);
                }
            }
        }
    }
}