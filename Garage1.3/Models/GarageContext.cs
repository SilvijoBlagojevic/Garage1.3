using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage1._3.Models
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("GarageContext")
        {
        }
        public DbSet <Garage> Garages { get; set; }
    }
}