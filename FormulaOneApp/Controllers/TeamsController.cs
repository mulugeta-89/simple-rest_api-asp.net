using FormulaOneApp.Data;
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
namespace FormulaOneApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        public readonly AppDbContext _context;

        public TeamsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return BadRequest("No team found");
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", team.Id, team);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, string country)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return BadRequest("Invalid Id");
            }
            team.Country = country;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(y => y.Id == id);

            if(team == null)
            {
                return BadRequest("Invalid Id");
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
