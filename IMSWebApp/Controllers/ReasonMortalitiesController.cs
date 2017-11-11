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
    public class ReasonMortalitiesController : Controller
    {
        private readonly fishinaboxContext _context;

        public ReasonMortalitiesController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: ReasonMortalities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReasonMortality.ToListAsync());
        }

        // GET: ReasonMortalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reasonMortality = await _context.ReasonMortality
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (reasonMortality == null)
            {
                return NotFound();
            }

            return View(reasonMortality);
        }

        // GET: ReasonMortalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReasonMortalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,IdCode,Text")] ReasonMortality reasonMortality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reasonMortality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reasonMortality);
        }

        // GET: ReasonMortalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reasonMortality = await _context.ReasonMortality.SingleOrDefaultAsync(m => m.IdPk == id);
            if (reasonMortality == null)
            {
                return NotFound();
            }
            return View(reasonMortality);
        }

        // POST: ReasonMortalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,IdCode,Text")] ReasonMortality reasonMortality)
        {
            if (id != reasonMortality.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reasonMortality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReasonMortalityExists(reasonMortality.IdPk))
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
            return View(reasonMortality);
        }

        // GET: ReasonMortalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reasonMortality = await _context.ReasonMortality
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (reasonMortality == null)
            {
                return NotFound();
            }

            return View(reasonMortality);
        }

        // POST: ReasonMortalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reasonMortality = await _context.ReasonMortality.SingleOrDefaultAsync(m => m.IdPk == id);
            _context.ReasonMortality.Remove(reasonMortality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReasonMortalityExists(int id)
        {
            return _context.ReasonMortality.Any(e => e.IdPk == id);
        }
    }
}
