using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Speedtest.Dto;
using Speedtest.Models;

namespace Speedtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly EsemkaHeroContext _context;

        public HeroesController(EsemkaHeroContext context)
        {
            _context = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroDTO>>> GetHeroes()
        {
            var heroes = await _context.Heroes.Include(e => e.Clan).ToListAsync();
            return Ok(heroes.Select(e =>
            {
                return JsonConvert.DeserializeObject<HeroDTO>(JsonConvert.SerializeObject(e));
            }).ToList());
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroskillDTO>> GetHero(int id)
        {
            var hero = await _context.HeroSkills.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.DeserializeObject<HeroDTO>(JsonConvert.SerializeObject(hero)));
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, HeroDTO hero)
        {
            hero.Id = id;

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(HeroDTO hero)
        {
            hero.Id = 0;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}
