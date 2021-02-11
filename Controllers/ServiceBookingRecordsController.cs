using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Final_Proj.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Vehicle_Service_Final_Proj.Controllers
{

    public class ServiceBookingRecordsController : Controller
    {
        private readonly Vehicle_Service_DataContext _context;

        private SignInManager<IdentityUser> SignInManager;

        public ServiceBookingRecordsController(Vehicle_Service_DataContext context,
            SignInManager<IdentityUser> SignInManager
            
            )
        {
            this.SignInManager = SignInManager;
            _context = context;
        }

        // GET: ServiceBookingRecords
        [Authorize(Roles = "vehicle_admin, vehicle_owner")]
        public async Task<IActionResult> Index()
        {
            var vehicle_Service_DataContext = _context.ServiceBookingRecord.Include(s => s.Service).Include(s => s.VehicleOwner);

            if (SignInManager.IsSignedIn(User) && User.IsInRole("vehicle_owner")) {

                var vehicleBookings = _context.ServiceBookingRecord.
                    Include(s => s.Service).
                    Include(s => s.VehicleOwner)
                    .Where(s => s.VehicleOwner.Email.Equals(User.Identity.Name)).ToList();

                return View(vehicleBookings);

            }

            return View(await vehicle_Service_DataContext.ToListAsync());
        }

        // GET: ServiceBookingRecords/Details/5
        [Authorize(Roles = "vehicle_admin, vehicle_owner")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBookingRecord = await _context.ServiceBookingRecord
                .Include(s => s.Service)
                .Include(s => s.VehicleOwner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBookingRecord == null)
            {
                return NotFound();
            }

            return View(serviceBookingRecord);
        }

        // GET: ServiceBookingRecords/Create
        [Authorize(Roles = "vehicle_owner")]
        public IActionResult Create(int Id)
        {
            if (SignInManager.IsSignedIn(User)) {

                var vehicleOwner = (from owner in _context.VehicleOwner
                                   where owner.Email.Equals(User.Identity.Name)
                                   select owner).FirstOrDefault();

                //Create a New service Booking record 
                ServiceBookingRecord record = new ServiceBookingRecord();

                record.ServiceId = Id;
                record.VehicleOwnerId = vehicleOwner.Id;

                _context.Add(record);
                _context.SaveChanges();

                var createdServiceBooking = _context.ServiceBookingRecord.
                    Include(sr => sr.VehicleOwner)
                    .Include(sr => sr.Service)
                    .Where(sr => sr.Id == record.Id).FirstOrDefault();
                return View(createdServiceBooking);


            }


            return View();
        }


        // GET: ServiceBookingRecords/Edit/5
        [Authorize(Roles = "vehicle_admin, vehicle_owner")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBookingRecord = await _context.ServiceBookingRecord.FindAsync(id);
            if (serviceBookingRecord == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id", serviceBookingRecord.ServiceId);
            ViewData["VehicleOwnerId"] = new SelectList(_context.Set<VehicleOwner>(), "Id", "Id", serviceBookingRecord.VehicleOwnerId);
            return View(serviceBookingRecord);
        }

        // POST: ServiceBookingRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "vehicle_admin, vehicle_owner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceId,VehicleOwnerId")] ServiceBookingRecord serviceBookingRecord)
        {
            if (id != serviceBookingRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceBookingRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceBookingRecordExists(serviceBookingRecord.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id", serviceBookingRecord.ServiceId);
            ViewData["VehicleOwnerId"] = new SelectList(_context.Set<VehicleOwner>(), "Id", "Id", serviceBookingRecord.VehicleOwnerId);
            return View(serviceBookingRecord);
        }

        // GET: ServiceBookingRecords/Delete/5
        [Authorize(Roles = "vehicle_admin, vehicle_owner")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBookingRecord = await _context.ServiceBookingRecord
                .Include(s => s.Service)
                .Include(s => s.VehicleOwner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBookingRecord == null)
            {
                return NotFound();
            }

            return View(serviceBookingRecord);
        }

        // POST: ServiceBookingRecords/Delete/5
        [Authorize(Roles = "vehicle_admin, vehicle_owner")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceBookingRecord = await _context.ServiceBookingRecord.FindAsync(id);
            _context.ServiceBookingRecord.Remove(serviceBookingRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceBookingRecordExists(int id)
        {
            return _context.ServiceBookingRecord.Any(e => e.Id == id);
        }
    }
}
