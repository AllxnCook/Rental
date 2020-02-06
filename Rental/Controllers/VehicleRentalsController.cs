using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;
using Rental.Models.ViewModels;

namespace Rental.Controllers
{
    public class VehicleRentalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VehicleRentalsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: VehicleRentals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VehicleRentals.Include(v => v.PaymentType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VehicleRentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            RentAVehicleViewModel vm = new RentAVehicleViewModel();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (id == null)
            {
                return NotFound();
            }

            vm.vehicleRental = await _context.VehicleRentals
                .Include(v => v.PaymentType)
                .Include(v => v.vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            if (vm == null)
            {
                return NotFound();
            }
            // calculating the pricing for each rental by the hour
            var hours = vm.vehicleRental.EndTime - vm.vehicleRental.StartTime;
            double hrs = hours.TotalHours;
            var pricing = vm.vehicleRental.vehicle.PricePerHour;
            vm.totalCost = hrs * pricing;
            
            return View(vm);
        }

        // GET: VehicleRentals/Create
        public async Task<IActionResult> Create(int id)
        {            
            //creating new SelectList item to run in the paymentTypes dropdown
    
            RentAVehicleViewModel vm = new RentAVehicleViewModel();
            // getting vehicle and start date by user
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            
            //attaching list of payment types to the view model
            vm.ListOfPaymentTypes = _context.PaymentType.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            // attaching all vehicle information to the view model
            vm.vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            vm.vehicleRental = new VehicleRental();
            vm.vehicleRental.ApplicationUserId = currentUser.Id;
            vm.vehicleRental.StartTime = DateTime.Now;
            vm.vehicleRental.VehicleId = id;
            _context.Add(vm.vehicleRental);
            await _context.SaveChangesAsync();

            return View(vm);
        }

        // POST: VehicleRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentAVehicleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                vm.vehicleRental.ApplicationUserId = currentUser.Id;
                _context.Add(vm.vehicleRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(vm);
        }

        // GET: VehicleRentals/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //creating an instance of the viewmodel and verifying user
            RentAVehicleViewModel vm = new RentAVehicleViewModel();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var vehicleRental = await _context.VehicleRentals.FindAsync(id);
            // getting vehicle by view model information
            vm.vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            vm.vehicleRental = new VehicleRental();
            vm.vehicleRental.StartTime = vehicleRental.StartTime;
            
            vm.vehicleRental.PaymentType = vehicleRental.PaymentType;
            vm.vehicleRental.ApplicationUserId = currentUser.Id.ToString();
            vm.vehicleRental.VehicleId = id;
            _context.Add(vm.vehicleRental);
            await _context.SaveChangesAsync();

            return View(vm);


            
        }

        // POST: VehicleRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RentAVehicleViewModel vm)
        {
          if (ModelState.IsValid)
                {
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    vm.vehicleRental.ApplicationUserId = currentUser.Id;
                vm.vehicleRental.EndTime = DateTime.Now;
                _context.Update(vm.vehicleRental);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Details", new { id = vm.vehicleRental.Id});
            }

            // GET: VehicleRentals/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRental = await _context.VehicleRentals
                .Include(v => v.PaymentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleRental == null)
            {
                return NotFound();
            }

            return View(vehicleRental);
        }

        // POST: VehicleRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleRental = await _context.VehicleRentals.FindAsync(id);
            _context.VehicleRentals.Remove(vehicleRental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleRentalExists(int id)
        {
            return _context.VehicleRentals.Any(e => e.Id == id);
        }
    }
}
