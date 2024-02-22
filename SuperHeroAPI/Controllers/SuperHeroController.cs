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
		[HttpPut]

		public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
		{
			var DBhero = await _context.SuperHeroes.FindAsync(updatedHero.ID);
			if(DBhero == null)
			{
				BadRequest("Hero not found...");
			}
			DBhero.Name = updatedHero.Name;
			DBhero.FirstName = updatedHero.FirstName;
			DBhero.LastName = updatedHero.LastName;
			DBhero.Place = updatedHero.Place;	

			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeroes.ToListAsync());
		}
		[HttpDelete]

		public async Task<ActionResult<List<SuperHero>>> DeleteHero(SuperHero updatedHero)
		{
			var DBhero = await _context.SuperHeroes.FindAsync(updatedHero.ID);
			if (DBhero == null)
			{
				BadRequest("Hero not found...");
			}
	
			_context.SuperHeroes.Remove(DBhero);
			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeroes.ToListAsync());
		}
	}
}
