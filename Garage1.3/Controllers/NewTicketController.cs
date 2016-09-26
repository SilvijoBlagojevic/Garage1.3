using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage1._3.Models;

namespace Garage1._3.Controllers
{
    public class NewTicketController : Controller
    {
        private GarageContext db = new GarageContext();
        Random rnd = new Random();

        // GET: Garages

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New([Bind(Include = "garageId,Plate,ParkingSpot")]Garage garage)
        {
            bool alreadyInDb = (from p in db.Garages where p.TimeOfDeparture == null
                                && p.ParkingSpot == garage.ParkingSpot
                                select p).Any();

            if (alreadyInDb)
            {
                ModelState.AddModelError("", "Parking place may not exist or all of 50 parking spaces are busy");
                return View();
            }

            int numberOfBusySpots = (from x in db.Garages where x.TimeOfDeparture == null select x).Count();

            if (numberOfBusySpots <= 50 && (garage.ParkingSpot > 1 && !(garage.ParkingSpot <=50)))
            {
                ModelState.AddModelError("", "That place is busy!");
                return View();
            }


            garage.TimeOfArrival = DateTime.Now;
            garage.UniqueCode = rnd.Next(1000, 10000);
            if (ModelState.IsValid)
            {
                string up = garage.Plate.ToUpper();
                garage.Plate = up;
                db.Garages.Add(garage);
                db.SaveChanges();
                return PartialView("_Success", garage);
            }else

            return View();
        }

        public ActionResult ListAllTickets()
        {
            return View(db.Garages.ToList());
        }


        [HttpPost]
        public ActionResult Delete(int garageId)
        {
            Garage garage = (from x in db.Garages where x.garageId == garageId select x).FirstOrDefault();
            Garage deletedGarage = db.Garages.Remove(garage);

            if (deletedGarage != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedGarage.Plate);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Garages");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
