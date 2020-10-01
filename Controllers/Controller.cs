using Database.Repository;
using Microsoft.AspNetCore.Mvc;

namespace afalunchrestapi.Controllers {
    [ApiController]
    [Route ("api")]
    public class Controller : ControllerBase {
        public DbRepo dbrepo = new DbRepo ();

        [HttpGet ("allfood")]
        public ActionResult<string> AllData () {

            dbrepo.StartRecievingFromDB ();

            return new OkObjectResult (this.dbrepo.AllJsonData);
        }
    }
}