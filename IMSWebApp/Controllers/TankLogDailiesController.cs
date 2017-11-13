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
    public class TankLogDailiesController : Controller
    {
        private readonly fishinaboxContext _context;

        public TankLogDailiesController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: TankLogDailies
        public async Task<IActionResult> Index()
        {
            var fishinaboxContext = _context.TankLogDaily.AsNoTracking().Include(t => t.LogFkNavigation).Include(t => t.ReasonFkNavigation).Include(t => t.StuffFkNavigation)
                                                       .Include(t => t.LogFkNavigation.TankFkNavigation)
                                                       .Include(t => t.LogFkNavigation.SpeciesFkNavigation );
            return View(await fishinaboxContext.ToListAsync());
        }

        // GET: TankLogDailies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankLogDaily = await _context.TankLogDaily
                .Include(t => t.LogFkNavigation)
                .Include(t => t.ReasonFkNavigation)
                .Include(t => t.StuffFkNavigation)
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankLogDaily == null)
            {
                return NotFound();
            }

            return View(tankLogDaily);
        }

        // GET: TankLogDailies/Create
        public IActionResult Create()
        {
            //ViewData["LogFk"] = new SelectList(_context.TankLog, "IdPk", "IdPk");

            /* need to display multiple field information on the dropdownlist
                 so that user can pick the right tank log record */
            ViewData["LogFk"] = new SelectList( 
                ( from x in _context.TankLog
                  select new
                  {
                      IdPk = x.IdPk,
                      Text = x.TankFkNavigation.IdCode + " " + // Tank Code ID
                             x.SpeciesFkNavigation.Scientific + // Species 
                             " [Qty:" + x.Qty + "]" // Quantity
                  }
                 ),"IdPk", "Text");

            ViewData["ReasonFk"] = new SelectList(_context.ReasonMortality, "IdPk", "Text");
            ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode");
            return View();
        }

        // POST: TankLogDailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,LogDate,LogFk,ReasonFk,Qty,Comment,StuffFk")] TankLogDaily tankLogDaily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tankLogDaily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["LogFk"] = new SelectList(_context.TankLog, "IdPk", "IdPk", tankLogDaily.LogFk);

            /* need to display multiple field information on the dropdownlist
                 so that user can pick the right tank log record */
            ViewData["LogFk"] = new SelectList(
                (from x in _context.TankLog
                 select new
                 {
                     IdPk = x.IdPk,
                     Text = x.TankFkNavigation.IdCode + " " + // Tank Code ID
                            x.SpeciesFkNavigation.Scientific + // Species 
                            " [Qty:" + x.Qty + "]" // Quantity
                 }
                 ), "IdPk", "Text", tankLogDaily.LogFk);

            ViewData["ReasonFk"] = new SelectList(_context.ReasonMortality, "IdPk", "Text", tankLogDaily.ReasonFk);
            ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLogDaily.StuffFk);
            return View(tankLogDaily);
        }

        // GET: TankLogDailies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankLogDaily = await _context.TankLogDaily.SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankLogDaily == null)
            {
                return NotFound();
            }
            //ViewData["LogFk"] = new SelectList(_context.TankLog, "IdPk", "IdPk", tankLogDaily.LogFk);

            /* need to display multiple field information on the dropdownlist
                 so that user can pick the right tank log record */
            ViewData["LogFk"] = new SelectList(
                (from x in _context.TankLog
                 select new
                 {
                     IdPk = x.IdPk,
                     Text = x.TankFkNavigation.IdCode + " " + // Tank Code ID
                            x.SpeciesFkNavigation.Scientific + // Species 
                            " [Qty:" + x.Qty + "]" // Quantity
                 }
                 ), "IdPk", "Text", tankLogDaily.LogFk);

            ViewData["ReasonFk"] = new SelectList(_context.ReasonMortality, "IdPk", "Text", tankLogDaily.ReasonFk);
            ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLogDaily.StuffFk);
            return View(tankLogDaily);
        }

        // POST: TankLogDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,LogDate,LogFk,ReasonFk,Qty,Comment,StuffFk")] TankLogDaily tankLogDaily)
        {
            if (id != tankLogDaily.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tankLogDaily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TankLogDailyExists(tankLogDaily.IdPk))
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
            //ViewData["LogFk"] = new SelectList(_context.TankLog, "IdPk", "IdPk", tankLogDaily.LogFk);

            /* need to display multiple field information on the dropdownlist
                 so that user can pick the right tank log record */
            ViewData["LogFk"] = new SelectList(
                (from x in _context.TankLog
                 select new
                 {
                     IdPk = x.IdPk,
                     Text = x.TankFkNavigation.IdCode + " " + // Tank Code ID
                            x.SpeciesFkNavigation.Scientific + // Species 
                            " [Qty:" + x.Qty + "]" // Quantity
                 }
                 ), "IdPk", "Text", tankLogDaily.LogFk);

            ViewData["ReasonFk"] = new SelectList(_context.ReasonMortality, "IdPk", "Text", tankLogDaily.ReasonFk);
            ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLogDaily.StuffFk);
            return View(tankLogDaily);
        }

        // GET: TankLogDailies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankLogDaily = await _context.TankLogDaily
                .Include(t => t.LogFkNavigation)
                .Include(t => t.ReasonFkNavigation)
                .Include(t => t.StuffFkNavigation)
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankLogDaily == null)
            {
                return NotFound();
            }

            return View(tankLogDaily);
        }

        // POST: TankLogDailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tankLogDaily = await _context.TankLogDaily.SingleOrDefaultAsync(m => m.IdPk == id);
            _context.TankLogDaily.Remove(tankLogDaily);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TankLogDailyExists(int id)
        {
            return _context.TankLogDaily.Any(e => e.IdPk == id);
        }
    }
}
