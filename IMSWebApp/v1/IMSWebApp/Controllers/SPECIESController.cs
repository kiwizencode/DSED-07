using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMSWebApp.Models.DataModel;

namespace IMSWebApp.Controllers
{
    public class SPECIESController : Controller
    {
        private readonly DataContext _context;

        public SPECIESController(DataContext context)
        {
            _context = context;
        }

        // GET: SPECIES
        public async Task<IActionResult> Index()
        {
            return View(await _context.SPECIES.ToListAsync());
        }

        // GET: SPECIES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sPECIES = await _context.SPECIES
                .SingleOrDefaultAsync(m => m.ID_PK == id);
            if (sPECIES == null)
            {
                return NotFound();
            }

            return View(sPECIES);
        }

        // GET: SPECIES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SPECIES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_PK,SCIENTIFIC,COMMON")] SPECIES sPECIES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sPECIES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sPECIES);
        }

        // GET: SPECIES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sPECIES = await _context.SPECIES.SingleOrDefaultAsync(m => m.ID_PK == id);
            if (sPECIES == null)
            {
                return NotFound();
            }
            return View(sPECIES);
        }

        // POST: SPECIES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_PK,SCIENTIFIC,COMMON")] SPECIES sPECIES)
        {
            if (id != sPECIES.ID_PK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sPECIES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SPECIESExists(sPECIES.ID_PK))
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
            return View(sPECIES);
        }

        // GET: SPECIES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sPECIES = await _context.SPECIES
                .SingleOrDefaultAsync(m => m.ID_PK == id);
            if (sPECIES == null)
            {
                return NotFound();
            }

            return View(sPECIES);
        }

        // POST: SPECIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sPECIES = await _context.SPECIES.SingleOrDefaultAsync(m => m.ID_PK == id);
            _context.SPECIES.Remove(sPECIES);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SPECIESExists(int id)
        {
            return _context.SPECIES.Any(e => e.ID_PK == id);
        }
    }
}
