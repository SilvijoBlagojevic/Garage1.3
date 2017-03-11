using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage1._3.Models
{
    public class Garage
    {
        public int garageId { get; set; }

        
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Min 4 characters is required, max 12")]
        [Required(ErrorMessage = "Plates nummbers is required")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "For registration plate please use only letters and numbers")]
        [Display(Name = "Registration plate")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "Position of car is required")]
        [Display(Name = "Parking spot number")]
        [Range(1, 50)]
        public int ParkingSpot { get; set; }

        [Display(Name = "Your Uniqe Code")]
        public int UniqueCode { get; set; }

        [Display(Name = "Time Of Arrival")]
        public DateTime TimeOfArrival { get; set; }

        [Display(Name = "Time Of Departure")]
        public DateTime ? TimeOfDeparture { get; set; }

        [Display(Name = "For Charge in €")]

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double? TimeForCharge { get; set; }

    }
}