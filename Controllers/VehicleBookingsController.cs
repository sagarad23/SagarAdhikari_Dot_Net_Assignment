using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleServiceBookingApp.Data;
using VehicleServiceBookingApp.Models;

namespace VehicleServiceBookingApp.Controllers
{
    public class VehicleBookingsController : Controller
    {
        private readonly VehicleServiceContext _context;

        public VehicleBookingsController(VehicleServiceContext context)
        {
            _context = context;
        }

        // GET: VehicleBookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleBookings.ToListAsync());
        }

        // GET: VehicleBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBooking = await _context.VehicleBookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // GET: VehicleBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,VehicleNumber,ServiceDate,ServiceType")] VehicleBooking vehicleBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleBooking);
        }

        // GET: VehicleBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBooking = await _context.VehicleBookings.FindAsync(id);
            if (vehicleBooking == null)
            {
                return NotFound();
            }
            return View(vehicleBooking);
        }

        // POST: VehicleBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,VehicleNumber,ServiceDate,ServiceType")] VehicleBooking vehicleBooking)
        {
            if (id != vehicleBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleBookingExists(vehicleBooking.Id))
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
            return View(vehicleBooking);
        }

        // GET: VehicleBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBooking = await _context.VehicleBookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // POST: VehicleBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleBooking = await _context.VehicleBookings.FindAsync(id);
            if (vehicleBooking != null)
            {
                _context.VehicleBookings.Remove(vehicleBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleBookingExists(int id)
        {
            return _context.VehicleBookings.Any(e => e.Id == id);
        }
    }
}
