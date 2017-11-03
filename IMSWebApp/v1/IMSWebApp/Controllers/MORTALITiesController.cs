﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMSWebApp.Models.DataModel;

namespace IMSWebApp.Controllers
{
    public class MORTALITiesController : Controller
    {
        private readonly DataContext _context;

        public MORTALITiesController(DataContext context)
        {
            _context = context;
        }

        // GET: MORTALITies
        public async Task<IActionResult> Index()
        {
            return View(await _context.MORTALITY.ToListAsync());
        }

        // GET: MORTALITies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mORTALITY = await _context.MORTALITY
                .SingleOrDefaultAsync(m => m.ID_PK == id);
            if (mORTALITY == null)
            {
                return NotFound();
            }

            return View(mORTALITY);
        }

        // GET: MORTALITies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MORTALITies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_PK,TEXT")] MORTALITY mORTALITY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mORTALITY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mORTALITY);
        }

        // GET: MORTALITies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mORTALITY = await _context.MORTALITY.SingleOrDefaultAsync(m => m.ID_PK == id);
            if (mORTALITY == null)
            {
                return NotFound();
            }
            return View(mORTALITY);
        }

        // POST: MORTALITies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_PK,TEXT")] MORTALITY mORTALITY)
        {
            if (id != mORTALITY.ID_PK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mORTALITY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MORTALITYExists(mORTALITY.ID_PK))
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
            return View(mORTALITY);
        }

        // GET: MORTALITies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mORTALITY = await _context.MORTALITY
                .SingleOrDefaultAsync(m => m.ID_PK == id);
            if (mORTALITY == null)
            {
                return NotFound();
            }

            return View(mORTALITY);
        }

        // POST: MORTALITies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mORTALITY = await _context.MORTALITY.SingleOrDefaultAsync(m => m.ID_PK == id);
            _context.MORTALITY.Remove(mORTALITY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MORTALITYExists(int id)
        {
            return _context.MORTALITY.Any(e => e.ID_PK == id);
        }
    }
}
