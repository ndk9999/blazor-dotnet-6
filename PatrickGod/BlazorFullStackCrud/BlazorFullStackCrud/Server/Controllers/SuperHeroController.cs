using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private static readonly List<Comic> _comics = new List<Comic> 
        {
            new Comic() {Id = 1, Name = "Marvel"},
            new Comic() {Id = 2, Name = "DC"},
        };
        private static readonly List<SuperHero> _heroes = new List<SuperHero>
        {
            new SuperHero()
            {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                ComicId = 1,
                Comic = _comics[0]
            },
            new SuperHero()
            {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                ComicId = 2,
                Comic = _comics[1]
            }
        };


        public SuperHeroController(ILogger<SuperHeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes()
        {
            return Ok(_heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = _heroes.FirstOrDefault(x => x.Id == id);

            if (hero is null) return NotFound("Sorry, no hero here. :/");

            return Ok(hero);
        }
    }
}
