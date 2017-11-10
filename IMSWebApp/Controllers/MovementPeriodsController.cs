using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMSWebApp.Models;

namespace IMSWebApp.Controllers
{
    public class MovementPeriodsController : Controller
    {
        private readonly fishinaboxContext _context;

        public MovementPeriodsController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: MovementPeriods
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovementPeriod.ToListAsync());
        }

        // GET: MovementPeriods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movementPeriod = await _context.MovementPeriod
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (movementPeriod == null)
            {
                return NotFound();
            }

            return View(movementPeriod);
        }

        // GET: MovementPeriods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovementPeriods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,StartDate,Text,ClosedDate,ClosedFlag")] MovementPeriod movementPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movementPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movementPeriod);
        }

        // GET: MovementPeriods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movementPeriod = await _context.MovementPeriod.SingleOrDefaultAsync(m => m.IdPk == id);
            if (movementPeriod == null)
            {
                return NotFound();
            }
            return View(movementPeriod);
        }

        // POST: MovementPeriods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,StartDate,Text,ClosedDate,ClosedFlag")] MovementPeriod movementPeriod)
        {
            if (id != movementPeriod.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movementPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovementPeriodExists(movementPeriod.IdPk))
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
            return View(movementPeriod);
        }

        // GET: MovementPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movementPeriod = await _context.MovementPeriod
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (movementPeriod == null)
            {
                return NotFound();
            }

            return View(movementPeriod);
        }

        // POST: MovementPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movementPeriod = await _context.MovementPeriod.SingleOrDefaultAsync(m => m.IdPk == id);
            _context.MovementPeriod.Remove(movementPeriod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovementPeriodExists(int id)
        {
            return _context.MovementPeriod.Any(e => e.IdPk == id);
        }
    }
}
