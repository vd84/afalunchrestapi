using System;
namespace Dbitems.MenuItem {
    public class MenuItem {
        public int Id { get; set; }
        public string NameOfDay { get; set; }
        public string Title { get; set; }
        public int IdOfRestaurant { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }
        //comment

        public void SetNameOfDay () {
            DayOfWeek weekdayToday = DateTime.Today.DayOfWeek;

            if (this.IdOfRestaurant == 2) {
                switch (this.Id) {
                    case 0:
                        this.NameOfDay = "Monday";
                        break;
                    case 1:
                        this.NameOfDay = "Tuesday";
                        break;
                    case 2:
                        this.NameOfDay = "Wednesday";
                        break;
                    case 3:
                        this.NameOfDay = "Thursday";
                        break;
                    case 4:
                        this.NameOfDay = "Friday";
                        break;
                }
            } else if (this.IdOfRestaurant == 1) {

                switch (this.Id) {
                    case 0:
                        this.NameOfDay = weekdayToday.ToString ();
                        break;
                    case 1:
                        this.NameOfDay = DateTime.Today.AddDays (1).DayOfWeek.ToString ();
                        break;
                    case 2:
                        this.NameOfDay = DateTime.Today.AddDays (2).DayOfWeek.ToString ();
                        break;
                    case 3:
                        this.NameOfDay = DateTime.Today.AddDays (3).DayOfWeek.ToString ();
                        break;
                    case 4:
                        this.NameOfDay = DateTime.Today.AddDays (4).DayOfWeek.ToString ();
                        break;
                    default:
                        this.NameOfDay = "Kan beställas alla dagar";
                        break;
                }

            }
        }

    }
}