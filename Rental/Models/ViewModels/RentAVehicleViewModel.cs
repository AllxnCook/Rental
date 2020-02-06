using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models.ViewModels
{
    public class RentAVehicleViewModel
    {
        public Vehicle vehicle { get; set; }
        public VehicleRental vehicleRental { get; set; }
        public List<SelectListItem> ListOfPaymentTypes { get; set; } = new List<SelectListItem>();
        public PaymentType paymentType { get; set; }
        [Display(Name = "Amount Spent $")]
        public double totalCost { get; set; }
        



    }
}
