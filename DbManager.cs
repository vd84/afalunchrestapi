using System.Collections.Generic;
using Dbitems.MenuItem;
using Dbitems.RestaurantItem;
using Npgsql;
namespace database.manager {
    public class DbManager {

        public string ConnectionString { get; set; }
        public NpgsqlConnection Connection { get; set; }

        public DbManager () {
            this.ConnectionString = "Host=172.18.0.1;Username=postgres;Password=postgres;Database=postgres";
            System.Console.WriteLine (this.ConnectionString);
            this.Connection = new NpgsqlConnection (this.ConnectionString);
            this.Connect ();
        }

        public void Connect () {
            this.Connection.Open ();

            var createRestautantSql = "CREATE TABLE IF NOT EXISTS RESTAURANT(RESTAURANT_ID INT PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,RESTAURANT_NAME VARCHAR(255) NOT NULL,PHONE VARCHAR(15) NOT NULL,ADDRESS VARCHAR(100) NOT NULL)";
            var createMenuSql = "CREATE TABLE IF NOT EXISTS MENU(MENU_ID INT PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,WEEKDAY INT,MENU_NAME VARCHAR(255),INGREDIENTS VARCHAR(255),PRICE INT,RESTAURANT_ID INT NOT NULL,CONSTRAINT FK_RESTAURANT FOREIGN KEY(RESTAURANT_ID) REFERENCES RESTAURANT(RESTAURANT_ID))";

            var cmd = new NpgsqlCommand (createRestautantSql, this.Connection);

            cmd.ExecuteScalar ();

            cmd = new NpgsqlCommand (createMenuSql, this.Connection);

            cmd.ExecuteScalar ();

            var insertResturangSql = "INSERT INTO RESTAURANT( RESTAURANT_NAME, PHONE, ADDRESS) values ('Diwine', '08-212885', 'Drottninggatan 25 111 51 Stockholm' )";
            cmd = new NpgsqlCommand (insertResturangSql, this.Connection);

            cmd.ExecuteScalar ();

            insertResturangSql = "INSERT INTO RESTAURANT(RESTAURANT_NAME, PHONE, ADDRESS) values ('IlMolo', '08-20 36 30',  'Hamngatan 37, 111 53 Stockholm')";
            cmd = new NpgsqlCommand (insertResturangSql, this.Connection);
            cmd.ExecuteScalar ();

        }

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
                menuItem.SetNameOfDay ();
                listOfMenuItems.Add (menuItem);
            }

            string jsonList = Newtonsoft.Json.JsonConvert.SerializeObject (listOfMenuItems, Newtonsoft.Json.Formatting.Indented);
            System.Console.WriteLine (jsonList);
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

        public string SelectAllDishesFromSpecificRestaurant (int id) {
            var sql = $"SELECT * FROM MENU WHERE MENU.RESTAURANT_ID = {id}";
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
                menuItem.SetNameOfDay ();
                listOfMenuItems.Add (menuItem);
            }
            string jsonList = Newtonsoft.Json.JsonConvert.SerializeObject (listOfMenuItems, Newtonsoft.Json.Formatting.Indented);
            System.Console.WriteLine (jsonList);
            return jsonList;
        }
    }
}