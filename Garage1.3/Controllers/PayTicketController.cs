using Garage1._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1._3.Controllers
{
    public class PayTicketController : Controller
    {
        private GarageContext db = new GarageContext();

        public ActionResult Pay()
        {
            return View("Pay");
        }

        [HttpPost]
        public ActionResult Pay(string plate, int uniqueCode)
        {
            
            string up = plate.ToUpper();
            plate = up;
            Garage garage = (from b in db.Garages
                             where b.Plate == plate && b.UniqueCode == uniqueCode
                             select b).FirstOrDefault();
            if(garage != null)
            {
                garage.TimeOfDeparture = DateTime.Now;
                var helper = garage.TimeOfDeparture - garage.TimeOfArrival;
                garage.TimeForCharge = helper.Value.TotalHours + 1;
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Please check your Plate nummber or Uniqe Code");
                return View();
            }

            TempData["message"] = string.Format("Car with {0} plates and Uniqe code {1} is succesful pay {2 : 0.00 } €, Your Car is on {3} spot", garage.Plate, garage.UniqueCode, garage.TimeForCharge, garage.ParkingSpot);
            return View("Details", garage);
        }


    }
}