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

        // GET: VehicleRentals/Create
        public async Task<IActionResult> Create(int? id)
        {
            //creating new SelectList item to run in the paymentTypes dropdown
            //ViewData["PaymentTypeId"] = new SelectList(_context.Set<PaymentType>(), "Id", "Id");
        RentAVehicleViewModel vm = new RentAVehicleViewModel();
            //attaching list of payment types to the view model
            vm.ListOfPaymentTypes = _context.PaymentType.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            vm.ListOfPaymentTypes.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please Choose a Payment Method!"
            });
            // attaching all vehicle information to the view model
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

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
            //ViewData["PaymentTypeId"] = new SelectList(_context.Set<PaymentType>(), "Id", "Id", vm.PaymentTypeId);
            return View(vm);
        }

        // GET: VehicleRentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRental = await _context.VehicleRentals.FindAsync(id);
            if (vehicleRental == null)
            {
                return NotFound();
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.Set<PaymentType>(), "Id", "Id", vehicleRental.PaymentTypeId);
            return View(vehicleRental);
        }

        // POST: VehicleRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,PaymentTypeId,ApplicationUserId,VehicleId")] VehicleRental vehicleRental)
        {
            if (id != vehicleRental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleRental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleRentalExists(vehicleRental.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.Set<PaymentType>(), "Id", "Id", vehicleRental.PaymentTypeId);
            return View(vehicleRental);
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
