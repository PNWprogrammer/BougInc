using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CulturNary.Web.Models;

namespace CulturNary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalorieTrackerController : ControllerBase
    {
        private readonly CulturNaryDbContext _context;

        public CalorieTrackerController(CulturNaryDbContext context)
        {
            _context = context;
        }

        // GET: api/CalorieTracker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalorieTracker>>> GetCalorieTrackers()
        {
            return await _context.CalorieTrackers.ToListAsync();
        }

        // GET: api/CalorieTracker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalorieTracker>> GetCalorieTracker(int id)
        {
            var calorieTracker = await _context.CalorieTrackers.FindAsync(id);

            if (calorieTracker == null)
            {
                return NotFound();
            }

            return calorieTracker;
        }

        // PUT: api/CalorieTracker/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalorieTracker(int id, CalorieTracker calorieTracker)
        {
            if (id != calorieTracker.Id)
            {
                return BadRequest();
            }

            _context.Entry(calorieTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalorieTrackerExists(id))
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

        // POST: api/CalorieTracker
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalorieTracker>> PostCalorieTracker(CalorieTracker calorieTracker)
        {
            _context.CalorieTrackers.Add(calorieTracker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalorieTracker", new { id = calorieTracker.Id }, calorieTracker);
        }

        // DELETE: api/CalorieTracker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalorieTracker(int id)
        {
            var calorieTracker = await _context.CalorieTrackers.FindAsync(id);
            if (calorieTracker == null)
            {
                return NotFound();
            }

            _context.CalorieTrackers.Remove(calorieTracker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalorieTrackerExists(int id)
        {
            return _context.CalorieTrackers.Any(e => e.Id == id);
        }
    }
}
