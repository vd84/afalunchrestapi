using System;
using System.Text;
using System.Threading;
using database.manager;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Database.Repository {
    public class DbRepo {

        DbManager dbManager = new DbManager ();

        public string GetAllDishes () {
            return dbManager.SelectAllDishes ();
        }

        public string GetAllRestaurants () {
            return dbManager.SelectAllRestaurants ();
        }

        public string GetAllDishesFromSpecificRestaurant(int id) {

            return dbManager.SelectAllDishesFromSpecificRestaurant(id);


        }

    }
}