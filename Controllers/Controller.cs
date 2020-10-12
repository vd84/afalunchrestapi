using afalunchrestapi;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;

namespace afalunchrestapi.Controllers {
    [ApiController]
    [Route ("api")]
    public class Controller : ControllerBase {

        DbRepo dbrepo = new DbRepo ();


        [HttpGet ("allfood")]
        public ActionResult<string> AllData () {
            System.Console.WriteLine("asking for more data");
            return new OkObjectResult (dbrepo.GetAllDishes());
        }
        [HttpGet("allRestaurants")]
        public ActionResult<string> AllRestaurants(){
            return new OkObjectResult(dbrepo.GetAllRestaurants());
        }
        [HttpGet("allfood/{id}")]
        public ActionResult<string> AllDishesSpecificRestaurant(int id){
            return new OkObjectResult(dbrepo.GetAllDishesFromSpecificRestaurant(id));
        }
    }
}