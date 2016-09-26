using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1._3.Controllers
{
    public class GaragesController : Controller
    {
        // GET: Garages
        public ActionResult Index()
        {
            return View();
        }
    }
}