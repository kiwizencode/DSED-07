using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMSWebApp.Models;

namespace IMSWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/MPISpeciesAPI")]
    public class MPISpeciesAPIController : Controller
    {
        private readonly fishinaboxContext _context;

        public MPISpeciesAPIController(fishinaboxContext context)
        {
            _context = context;
        }

        // GET: api/MPISpeciesAPI
        [HttpGet]
        public IEnumerable<MarineSpecies> GetMarineSpecies()
        {
            return _context.MarineSpecies.Where(x => x.Flag==true);
        }

        // GET: api/MPISpeciesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarineSpecies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marineSpecies = await _context.MarineSpecies.SingleOrDefaultAsync(m => m.IdPk == id);

            if (marineSpecies == null)
            {
                return NotFound();
            }

            return Ok(marineSpecies);
        }

        private bool MarineSpeciesExists(int id)
        {
            return _context.MarineSpecies.Any(e => e.IdPk == id);
        }
    }
}