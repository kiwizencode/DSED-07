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
    public class TankBaysController : Controller
    {
        private readonly fishinaboxContext _context;

        public TankBaysController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: TankBays
        public async Task<IActionResult> Index()
        {
            return View(await _context.TankBay.ToListAsync());
        }

        // GET: TankBays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankBay = await _context.TankBay
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankBay == null)
            {
                return NotFound();
            }

            return View(tankBay);
        }

        // GET: TankBays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TankBays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,IdCode,Text")] TankBay tankBay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tankBay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tankBay);
        }

        // GET: TankBays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankBay = await _context.TankBay.SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankBay == null)
            {
                return NotFound();
            }
            return View(tankBay);
        }

        // POST: TankBays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,IdCode,Text")] TankBay tankBay)
        {
            if (id != tankBay.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tankBay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TankBayExists(tankBay.IdPk))
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
            return View(tankBay);
        }

        // GET: TankBays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankBay = await _context.TankBay
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankBay == null)
            {
                return NotFound();
            }

            return View(tankBay);
        }

        // POST: TankBays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tankBay = await _context.TankBay.SingleOrDefaultAsync(m => m.IdPk == id);
            _context.TankBay.Remove(tankBay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TankBayExists(int id)
        {
            return _context.TankBay.Any(e => e.IdPk == id);
        }
    }
}
