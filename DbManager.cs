using System.Collections.Generic;
using Dbitems.MenuItem;
using Dbitems.RestaurantItem;
using Npgsql;
namespace database.manager {
    public class DbManager {

        public string ConnectionString { get; set; }
        public NpgsqlConnection Connection { get; set; }

        public DbManager () {
            this.ConnectionString = "Host=127.0.0.1;Username=postgres;Password=postgres;Database=postgres";
            this.Connection = new NpgsqlConnection (this.ConnectionString);
            this.Connect ();
        }

        public void Connect () => this.Connection.Open ();

        public void INSERTINTOMENU (int weekday, string name, string ingredients, int price, int restaurantId) {

            var sql = $"INSERT INTO MENU (WEEKDAY, MENU_NAME, INGREDIENTS, PRICE, RESTAURANT_ID) VALUES ({weekday}, '{name}', '{ingredients}', {price}, {restaurantId})";

            System.Console.WriteLine (sql);

            var cmd = new NpgsqlCommand (sql, this.Connection);

            cmd.ExecuteScalar ();

            /* System.Console.WriteLine ("RESULTAS: " + result); */
        }

        public string SelectAllDishes () {

            var sql = "SELECT * FROM MENU";
            var cmd = new NpgsqlCommand (sql, this.Connection);

            NpgsqlDataReader data = cmd.ExecuteReader ();
            List<MenuItem> listOfMenuItems = new List<MenuItem> ();

            while (data.Read ()) {
                MenuItem menuItem = new MenuItem () {
                    Id = int.Parse (data[1].ToString ()),
                    Title = data[2].ToString (),
                    Ingredients = data[3].ToString (),
                    Price = int.Parse (data[4].ToString ()),
                    IdOfRestaurant = int.Parse (data[5].ToString ())
                };
                listOfMenuItems.Add (menuItem);
            }

            string jsonList = Newtonsoft.Json.JsonConvert.SerializeObject (listOfMenuItems, Newtonsoft.Json.Formatting.Indented);
            return jsonList;
        }

        public string SelectAllRestaurants () {
            var sql = "SELECT * FROM RESTAURANT";
            var cmd = new NpgsqlCommand (sql, this.Connection);
            NpgsqlDataReader data = cmd.ExecuteReader ();
            List<RestaurantItem> listOfRestaurants = new List<RestaurantItem> ();

            while (data.Read ()) {
                RestaurantItem menuItem = new RestaurantItem () {
                    Restaurant_Id = int.Parse (data[0].ToString ()),
                    Restaurant_Name = data[1].ToString (),
                    Phone = data[2].ToString (),
                    Adress = data[3].ToString (),
                };
                listOfRestaurants.Add (menuItem);
            }
            string jsonList = Newtonsoft.Json.JsonConvert.SerializeObject (listOfRestaurants, Newtonsoft.Json.Formatting.Indented);
            return jsonList;
        }
    }
}