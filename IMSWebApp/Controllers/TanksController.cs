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
    public class TanksController : Controller
    {
        private readonly fishinaboxContext _context;

        public TanksController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: Tanks
        public async Task<IActionResult> Index()
        {
            var fishinaboxContext = _context.Tank.Include(t => t.BayFkNavigation);
            return View(await fishinaboxContext.ToListAsync());
        }

        // GET: Tanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.Tank
                .Include(t => t.BayFkNavigation)
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);
        }

        // GET: Tanks/Create
        public IActionResult Create()
        {
            ViewData["BayFk"] = new SelectList(_context.TankBay, "IdPk", "IdCode");
            return View();
        }

        // POST: Tanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,BayFk,IdCode,Text,Rfid")] Tank tank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BayFk"] = new SelectList(_context.TankBay, "IdPk", "IdCode", tank.BayFk);
            return View(tank);
        }

        // GET: Tanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.Tank.SingleOrDefaultAsync(m => m.IdPk == id);
            if (tank == null)
            {
                return NotFound();
            }
            ViewData["BayFk"] = new SelectList(_context.TankBay, "IdPk", "IdCode", tank.BayFk);
            return View(tank);
        }

        // POST: Tanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,BayFk,IdCode,Text,Rfid")] Tank tank)
        {
            if (id != tank.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TankExists(tank.IdPk))
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
            ViewData["BayFk"] = new SelectList(_context.TankBay, "IdPk", "IdCode", tank.BayFk);
            return View(tank);
        }

        // GET: Tanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.Tank
                .Include(t => t.BayFkNavigation)
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tank = await _context.Tank.SingleOrDefaultAsync(m => m.IdPk == id);
            _context.Tank.Remove(tank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TankExists(int id)
        {
            return _context.Tank.Any(e => e.IdPk == id);
        }
    }
}
