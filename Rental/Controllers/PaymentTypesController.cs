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

namespace Rental.Controllers
{
    public class PaymentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        // giving the paymenttype user-related data with userManager
        public PaymentTypesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PaymentTypes
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.PaymentType.Where(p => p.UserId == currentUser.Id)
                .Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PaymentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentType
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AccountNumber,UserId")] PaymentType paymentType)
        {
            //removing user and userId from Modelstate
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            //checking if the current user is signed in before creating a payment type
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                paymentType.UserId = currentUser.Id;
                _context.Add(paymentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentType.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", paymentType.UserId);
            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AccountNumber,UserId")] PaymentType paymentType)
        {
            //checking to see if the payment type has an Id
            if (id != paymentType.Id)
            {
                return NotFound();
            }
            //removing user and userId from Modelstate
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    paymentType.UserId = currentUser.Id;
                    _context.Update(paymentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentTypeExists(paymentType.Id))
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
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentType
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentType = await _context.PaymentType.FindAsync(id);
            _context.PaymentType.Remove(paymentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentTypeExists(int id)
        {
            return _context.PaymentType.Any(e => e.Id == id);
        }
    }
}
