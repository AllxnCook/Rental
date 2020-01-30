using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class VehicleRental
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public string ApplicationUserId { get; set; }
        public int VehicleId { get; set; }
 
    }
}
