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
    public class TankLogsController : Controller
    {
        private readonly fishinaboxContext _context;

        public TankLogsController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: TankLogs
        public async Task<IActionResult> Index()
        {
            var fishinaboxContext = _context.TankLog.AsNoTracking().Include(t => t.PeriodFkNavigation).Include(t => t.SizeFkNavigation).Include(t => t.SpeciesFkNavigation).Include(t => t.StuffFkNavigation).Include(t => t.TankFkNavigation);
            return View(await fishinaboxContext.ToListAsync());
        }

        // GET: TankLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankLog = await _context.TankLog
                .Include(t => t.PeriodFkNavigation)
                .Include(t => t.SizeFkNavigation)
                .Include(t => t.SpeciesFkNavigation)
                .Include(t => t.StuffFkNavigation)
                .Include(t => t.TankFkNavigation)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankLog == null)
            {
                return NotFound();
            }

            return View(tankLog);
        }

        // GET: TankLogs/Create
        public IActionResult Create()
        {
            //ViewData["PeriodFk"] = new SelectList(_context.MovementPeriod, "IdPk", "StartDate");

            /* need to change the date format to be consistent with the way
               other page display date field, also add additional information to the dropdownlist */
            //ViewData["PeriodFk"] = new SelectList(
            //    (from x in _context.MovementPeriod
            //     select new
            //     {
            //         IdPk = x.IdPk,
            //         Text = x.StartDate.ToString("yyyy-MM-dd") +
            //               " " + x.Text 
            //      }
            //    ), 
            //    "IdPk", "Text");
            //ViewData["SizeFk"] = new SelectList(_context.RecordPetSize, "IdPk", "Description");
            //ViewData["SpeciesFk"] = new SelectList(_context.MarineSpecies.AsNoTracking(), "IdPk", "Scientific");
            //ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode");
            //ViewData["TankFk"] = new SelectList(_context.Tank, "IdPk", "IdCode");
            initialiseViewData();
            return View();
        }

        // POST: TankLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPk,PeriodFk,TankFk,SpeciesFk,SpeciesText,SpeciesText2,Qty,Comment,StuffFk,OrderFk,SizeFk")] TankLog tankLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tankLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PeriodFk"] = new SelectList(_context.MovementPeriod, "IdPk", "StartDate", tankLog.PeriodFk);
            //ViewData["SizeFk"] = new SelectList(_context.RecordPetSize, "IdPk", "Description", tankLog.SizeFk);
            //ViewData["SpeciesFk"] = new SelectList(_context.MarineSpecies.AsNoTracking(), "IdPk", "Scientific", tankLog.SpeciesFk);
            //ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLog.StuffFk);
            //ViewData["TankFk"] = new SelectList(_context.Tank, "IdPk", "IdCode", tankLog.TankFk);
            initialiseViewData(tankLog);
            return View(tankLog);
        }

        // GET: TankLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankLog = await _context.TankLog.AsNoTracking().SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankLog == null)
            {
                return NotFound();
            }
            //ViewData["PeriodFk"] = new SelectList(_context.MovementPeriod, "IdPk", "IdPk", tankLog.PeriodFk);
            //ViewData["SizeFk"] = new SelectList(_context.RecordPetSize, "IdPk", "Description", tankLog.SizeFk);
            //ViewData["SpeciesFk"] = new SelectList(_context.MarineSpecies.AsNoTracking(), "IdPk", "Scientific", tankLog.SpeciesFk);
            //ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLog.StuffFk);
            //ViewData["TankFk"] = new SelectList(_context.Tank, "IdPk", "IdCode", tankLog.TankFk);
            initialiseViewData(tankLog);
            return View(tankLog);
        }

        // POST: TankLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPk,PeriodFk,TankFk,SpeciesFk,SpeciesText,SpeciesText2,Qty,Comment,StuffFk,OrderFk,SizeFk")] TankLog tankLog)
        {
            if (id != tankLog.IdPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tankLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TankLogExists(tankLog.IdPk))
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
            //ViewData["PeriodFk"] = new SelectList(_context.MovementPeriod, "IdPk", "IdPk", tankLog.PeriodFk);
            //ViewData["SizeFk"] = new SelectList(_context.RecordPetSize, "IdPk", "Description", tankLog.SizeFk);
            //ViewData["SpeciesFk"] = new SelectList(_context.MarineSpecies.AsNoTracking(), "IdPk", "Scientific", tankLog.SpeciesFk);
            //ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLog.StuffFk);
            //ViewData["TankFk"] = new SelectList(_context.Tank, "IdPk", "IdCode", tankLog.TankFk);
            initialiseViewData(tankLog);
            return View(tankLog);
        }

        // GET: TankLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tankLog = await _context.TankLog
                .Include(t => t.PeriodFkNavigation)
                .Include(t => t.SizeFkNavigation)
                .Include(t => t.SpeciesFkNavigation)
                .Include(t => t.StuffFkNavigation)
                .Include(t => t.TankFkNavigation)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.IdPk == id);
            if (tankLog == null)
            {
                return NotFound();
            }

            return View(tankLog);
        }

        // POST: TankLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tankLog = await _context.TankLog.AsNoTracking().SingleOrDefaultAsync(m => m.IdPk == id);
            _context.TankLog.Remove(tankLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TankLogExists(int id)
        {
            return _context.TankLog.AsNoTracking().Any(e => e.IdPk == id);
        }

        /* 
         I following the uri 
         https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data
         as an example for my following way of coding */
        private void initialiseViewData([Bind("IdPk,PeriodFk,TankFk,SpeciesFk,SpeciesText,SpeciesText2,Qty,Comment,StuffFk,OrderFk,SizeFk")] TankLog tankLog = null)
        {
            if(tankLog != null)
            {
                /* need to change the date format to be consistent with the way
                   other page display date field, also add additional information to the dropdownlist */
                ViewData["PeriodFk"] = new SelectList(
                    (from x in _context.MovementPeriod
                     select new
                     {
                         IdPk = x.IdPk,
                         Text = x.StartDate.ToString("yyyy-MM-dd") +
                               " " + x.Text
                     }
                    ),
                    "IdPk", "Text", tankLog.PeriodFk);
                ViewData["SizeFk"] = new SelectList(_context.RecordPetSize, "IdPk", "Description", tankLog.SizeFk);
                ViewData["SpeciesFk"] = new SelectList(_context.MarineSpecies.AsNoTracking(), "IdPk", "Scientific", tankLog.SpeciesFk);
                ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode", tankLog.StuffFk);
                ViewData["TankFk"] = new SelectList(_context.Tank, "IdPk", "IdCode", tankLog.TankFk);
            }
            else
            {
                /* need to change the date format to be consistent with the way
                   other page display date field, also add additional information to the dropdownlist */
                ViewData["PeriodFk"] = new SelectList(
                    (from x in _context.MovementPeriod
                     select new
                     {
                         IdPk = x.IdPk,
                         Text = x.StartDate.ToString("yyyy-MM-dd") +
                               " " + x.Text
                     }
                    ),
                    "IdPk", "Text");
                ViewData["SizeFk"] = new SelectList(_context.RecordPetSize, "IdPk", "Description");
                ViewData["SpeciesFk"] = new SelectList(_context.MarineSpecies.AsNoTracking(), "IdPk", "Scientific");
                ViewData["StuffFk"] = new SelectList(_context.SysStuff, "IdPk", "IdCode");
                ViewData["TankFk"] = new SelectList(_context.Tank, "IdPk", "IdCode");
            }
        }
    }
}
