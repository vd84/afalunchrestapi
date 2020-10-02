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
    }
}