using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rabbit.Reciever;

namespace afalunchrestapi.Controllers {
    [ApiController]
    [Route ("api")]
    public class Controller : ControllerBase {

        public DbRepo dbrepo = new DbRepo ();
        [HttpGet ("allfood")]
        public ActionResult<string> AllData () {
            System.Console.WriteLine ("testststs");

            dbrepo.StartRecievingFromDB ();
            System.Console.WriteLine(this.dbrepo.AllJsonData);
            return new OkObjectResult (this.dbrepo.AllJsonData);

        }

    }
}