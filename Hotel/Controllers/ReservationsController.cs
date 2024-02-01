﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Hotel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReservationsController : Controller
    {
        private readonly ReservationContext _context;

        public ReservationsController(ReservationContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var reservationContext = _context.Reservations.Include(r => r.Guests).Include(r => r.Rooms).Include(r => r.Service);
            return View(await reservationContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Guests)
                .Include(r => r.Rooms)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(m => m.ResID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Guests, "UserID", "UserID");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID");
            ViewData["ServiceID"] = new SelectList(_context.Services, "ServiceID", "ServiceID");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResID,RoomID,UserID,ServiceID,Startofdate,Endofdate,ReservationDescription")] Reservation reservation)
        {   
            
            
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["UserID"] = new SelectList(_context.Guests, "UserID", "UserID", reservation.UserID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", reservation.RoomID);
            ViewData["ServiceID"] = new SelectList(_context.Services, "ServiceID", "ServiceID", reservation.ServiceID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Guests, "UserID", "UserID", reservation.UserID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", reservation.RoomID);
            ViewData["ServiceID"] = new SelectList(_context.Services, "ServiceID", "ServiceID", reservation.ServiceID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResID,RoomID,UserID,ServiceID,Startofdate,Endofdate,ReservationDescription")] Reservation reservation)
        {
            if (id != reservation.ResID)
            {
                return NotFound();
            }

     
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ResID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["UserID"] = new SelectList(_context.Guests, "UserID", "UserID", reservation.UserID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", reservation.RoomID);
            ViewData["ServiceID"] = new SelectList(_context.Services, "ServiceID", "ServiceID", reservation.ServiceID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Guests)
                .Include(r => r.Rooms)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(m => m.ResID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ReservationContext.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.ResID == id)).GetValueOrDefault();
        }
    }
}
