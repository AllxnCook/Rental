using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public double PricePerHour { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string ImageURL { get; set; }
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }
}
