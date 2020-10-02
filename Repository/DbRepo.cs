using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using database.manager;

namespace Database.Repository {
    public class DbRepo {

        DbManager dbManager = new DbManager();

        public string GetAllDishes(){
            return dbManager.SelectAllDishes();
        }

        public string GetAllRestaurants() {
            return dbManager.SelectAllRestaurants();
        }







    }
}