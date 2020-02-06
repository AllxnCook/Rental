using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class VehicleRental
    {
        public int Id { get; set; }
        //[DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime StartTime { get; set; }
        //[DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime EndTime { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int VehicleId { get; set; }
        public string ApplicationUserId { get; set; }
        public Vehicle vehicle { get; set; }
 
    }
}
