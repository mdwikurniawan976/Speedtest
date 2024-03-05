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
    public class HeroSkillController : ControllerBase
    {
        private readonly EsemkaHeroContext _context;

        public HeroSkillController(EsemkaHeroContext context)
        {
            _context = context;
        }

        // GET: api/HeroSkill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroskillDTO>>> GetHeroSkills()
        {
            var heroeski = await _context.HeroSkills.Include(e => e.Hero).Include(f => f.Skill).ToListAsync();
            return Ok(heroeski.Select(e =>
            {
                return JsonConvert.DeserializeObject<HeroskillDTO>(JsonConvert.SerializeObject(e));
            }).ToList());
        }

        // GET: api/HeroSkill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroSkill>> GetHeroSkill(int id)
        {
            var heroSkill = await _context.HeroSkills.FindAsync(id);

            if (heroSkill == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.DeserializeObject<HeroskillDTO>(JsonConvert.SerializeObject(heroSkill)));
        }

        // PUT: api/HeroSkill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroSkill(int id, HeroskillDTO heroSkill)
        {
            heroSkill.Id = id;

            _context.Entry(heroSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroSkillExists(id))
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

        // POST: api/HeroSkill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeroSkill>> PostHeroSkill(HeroskillDTO heroSkill)
        {
            heroSkill.Id = 0;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroSkill", new { id = heroSkill.Id }, heroSkill);
        }

        // DELETE: api/HeroSkill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroSkill(int id)
        {
            var heroSkill = await _context.HeroSkills.FindAsync(id);
            if (heroSkill == null)
            {
                return NotFound();
            }

            _context.HeroSkills.Remove(heroSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroSkillExists(int id)
        {
            return _context.HeroSkills.Any(e => e.Id == id);
        }
    }
}
