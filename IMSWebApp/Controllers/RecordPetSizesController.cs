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
    public class RecordPetSizesController : Controller
    {
        private readonly fishinaboxContext _context;

        public RecordPetSizesController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: RecordPetSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecordPetSize.ToListAsync());
        }

        // GET: RecordPetSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordPetSize = await _context.RecordPetSize
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (recordPetSize == null)
            {
                return NotFound();
            }

            return View(recordPetSize);
        }

        // GET: RecordPetSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordPetSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,Description")] RecordPetSize recordPetSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recordPetSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordPetSize);
        }

        // GET: RecordPetSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordPetSize = await _context.RecordPetSize.SingleOrDefaultAsync(m => m.IdPk == id);
            if (recordPetSize == null)
            {
                return NotFound();
            }
            return View(recordPetSize);
        }

        // POST: RecordPetSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,Description")] RecordPetSize recordPetSize)
        {
            if (id != recordPetSize.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordPetSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordPetSizeExists(recordPetSize.IdPk))
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
            return View(recordPetSize);
        }

        // GET: RecordPetSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordPetSize = await _context.RecordPetSize
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (recordPetSize == null)
            {
                return NotFound();
            }

            return View(recordPetSize);
        }

        // POST: RecordPetSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordPetSize = await _context.RecordPetSize.SingleOrDefaultAsync(m => m.IdPk == id);
            _context.RecordPetSize.Remove(recordPetSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordPetSizeExists(int id)
        {
            return _context.RecordPetSize.Any(e => e.IdPk == id);
        }
    }
}
