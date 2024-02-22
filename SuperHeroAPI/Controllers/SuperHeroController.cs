using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
		public async Task<IActionResult> GetAllHeroes()
		{
			var heroes = await _context.SuperHeroes.ToListAsync();
			
			return Ok(heroes);	
		}
		[HttpGet("{id}")]
		
		public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
		{
			var hero = await _context.SuperHeroes.FindAsync(id);
			if(hero is null)
			{
				return BadRequest("Hero not found.");
			}
			return Ok(hero);
		}
		[HttpPost]

		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			_context.SuperHeroes.Add(hero);
			await _context.SaveChangesAsync();
			return Ok(await _context.SuperHeroes.ToListAsync());
		}
	}
}
