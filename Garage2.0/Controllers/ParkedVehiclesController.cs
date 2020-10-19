using Garage2._0.Data;
using Garage2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage2._0.Models.ViewModels;
using System;
using Microsoft.CodeAnalysis;

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
        // Added by Stefan search functionality
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.ParkedVehicle.ToListAsync();

            var model = new VehicleTypeViewModel
            {
                VehicleList = vehicles,
                VehicleTypes = await TypeAsync()
            };
            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> TypeAsync()
        {
            return await _context.ParkedVehicle
                         .Select(m => m.VehicleType)
                         .Distinct()
                         .Select(m => new SelectListItem
                         {
                             Text = m.ToString(),
                             Value = m.ToString()
                         })
                         .ToListAsync();
        }

        public async Task<IActionResult> Filter(VehicleTypeViewModel viewModel)
        {
            var vehicles = string.IsNullOrWhiteSpace(viewModel.SearchString) ?
                _context.ParkedVehicle :
                _context.ParkedVehicle.Where(m => m.RegNum.Contains(viewModel.SearchString));

            vehicles = viewModel.VehicleType == null ?
                vehicles :
                vehicles.Where(m => m.VehicleType == viewModel.VehicleType);

            var model = new VehicleTypeViewModel
            {
                VehicleList = await vehicles.ToListAsync(),
                VehicleTypes = await TypeAsync()
            };

            return View(nameof(Index), model);
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
                return RedirectToAction(nameof(Feedback), new { RegNum = parkedVehicle.RegNum, Message = "Has been updated" });
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
