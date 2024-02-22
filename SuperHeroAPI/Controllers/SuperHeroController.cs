using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllHeroes()
		{
			var heroes = new List<SuperHero>
			{
				new SuperHero
				{
					ID = 1,
					Name = "Spiderman",
					FirstName = "Peter",
					LastName = "Parker",
					Place = "New York City"
				}
			};
			return Ok(heroes);	
		}
	}
}
