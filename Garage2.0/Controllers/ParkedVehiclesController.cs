using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using Garage2._0.Models.ViewModels;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private const double costPerMinute = 0.1;

        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkedVehicle.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/CheckInVehicle
        public IActionResult CheckInVehicle()
        {
            return View();
        }

        // POST: ParkedVehicles/CheckInVehicle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckInVehicle([Bind("ID,VehicleType,RegNum,Color,Make,Model,NumOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VehicleType,RegNum,Color,Make,Model,NumOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.ID))
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
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Checkout/5
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FirstOrDefaultAsync(m => m.ID == id);

            if (parkedVehicle == null)
            {
                return NotFound();
            }
     
            var arrival = parkedVehicle.ArrivalTime;
            var checkout = DateTime.Now;

            var checkoutView = new CheckoutViewModel
            {
                RegNum = parkedVehicle.RegNum,
                ArrivalTime = arrival,
                CheckOutTime = checkout,
                Period = checkout - arrival,
                CostPerMinute = costPerMinute,
                Cost = Math.Round((checkout - arrival).TotalMinutes * costPerMinute, 2)
            };

            return View(checkoutView);
        }

        // POST: ParkedVehicles/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            var regnum = parkedVehicle.RegNum;
            var arrival = parkedVehicle.ArrivalTime;
            var checkout = DateTime.Now;

            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Receipt), new {RegNum = regnum, Arrival = arrival, Checkout = checkout});
        }

        public IActionResult Receipt(string regNum, DateTime arrival, DateTime checkout)
        {
            var receipt = new ReceiptViewModel
            {
                RegNum = regNum,
                ArrivalTime = arrival,
                CheckOutTime = checkout,
                Period = checkout - arrival,
                Cost = Math.Round((checkout - arrival).TotalMinutes * costPerMinute, 2)
            };

            return View(receipt);
        }

        public IActionResult Feedback(string regNum, string message)
        {
            var feedback = new FeedbackViewModel
            {
                RegNum = regNum,
                Message = message
            };
            return View(feedback);
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.ID == id);
        }
    }
}
