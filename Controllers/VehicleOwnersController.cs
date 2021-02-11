using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Final_Proj.Models;

namespace Vehicle_Service_Final_Proj.Controllers
{
    [Authorize(Roles= "vehicle_admin")]
    public class VehicleOwnersController : Controller
    {
        private readonly Vehicle_Service_DataContext _context;

        public VehicleOwnersController(Vehicle_Service_DataContext context)
        {
            _context = context;
        }

        // GET: VehicleOwners
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleOwner.ToListAsync());
        }

        // GET: VehicleOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleOwner = await _context.VehicleOwner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleOwner == null)
            {
                return NotFound();
            }

            return View(vehicleOwner);
        }

        // GET: VehicleOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ContactNumber,Email")] VehicleOwner vehicleOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleOwner);
        }

        // GET: VehicleOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleOwner = await _context.VehicleOwner.FindAsync(id);
            if (vehicleOwner == null)
            {
                return NotFound();
            }
            return View(vehicleOwner);
        }

        // POST: VehicleOwners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactNumber,Email")] VehicleOwner vehicleOwner)
        {
            if (id != vehicleOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleOwnerExists(vehicleOwner.Id))
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
            return View(vehicleOwner);
        }

        // GET: VehicleOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleOwner = await _context.VehicleOwner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleOwner == null)
            {
                return NotFound();
            }

            return View(vehicleOwner);
        }

        // POST: VehicleOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleOwner = await _context.VehicleOwner.FindAsync(id);
            _context.VehicleOwner.Remove(vehicleOwner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleOwnerExists(int id)
        {
            return _context.VehicleOwner.Any(e => e.Id == id);
        }
    }
}
