﻿using System;
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
    [Route("api/SpeciesAPI")]
    public class SpeciesAPIController : Controller
    {
        private readonly IMSystemContext _context;

        public SpeciesAPIController(IMSystemContext context)
        {
            _context = context;
        }

        // GET: api/SpeciesAPI
        [HttpGet]
        public IEnumerable<Species> GetSpecies()
        {
            return _context.Species;
        }

        // GET: api/SpeciesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var species = await _context.Species.SingleOrDefaultAsync(m => m.IdPk == id);

            if (species == null)
            {
                return NotFound();
            }

            return Ok(species);
        }

        // PUT: api/SpeciesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecies([FromRoute] int id, [FromBody] Species species)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != species.IdPk)
            {
                return BadRequest();
            }

            _context.Entry(species).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeciesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SpeciesAPI
        [HttpPost]
        public async Task<IActionResult> PostSpecies([FromBody] Species species)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Species.Add(species);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecies", new { id = species.IdPk }, species);
        }

        // DELETE: api/SpeciesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var species = await _context.Species.SingleOrDefaultAsync(m => m.IdPk == id);
            if (species == null)
            {
                return NotFound();
            }

            _context.Species.Remove(species);
            await _context.SaveChangesAsync();

            return Ok(species);
        }

        private bool SpeciesExists(int id)
        {
            return _context.Species.Any(e => e.IdPk == id);
        }
    }
}