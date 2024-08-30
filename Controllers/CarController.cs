using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGCWRegistration.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public ActionResult GetData()
        {
            // Simulate fetching data from a database or other source
            var data = new List<object>()
        {
            new { make="Tesla", model="Model Y", price=64950, electric=true, month="June" },
            new { make="Ford", model="F-Series", price=33850, electric=true, month="May" }
        };

            return Json(data, JsonRequestBehavior.AllowGet); // Allow GET requests for this action
        }

    }
}