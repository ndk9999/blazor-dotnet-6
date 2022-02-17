using BlazorFullStackCrud.Server.Data;
using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private readonly HeroContext _dbContext;


        public SuperHeroController(ILogger<SuperHeroController> logger, HeroContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes()
        {
            var heroes = await GetDbHeroes();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _dbContext.Heroes
                .Include(x => x.Comic)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (hero is null) return NotFound("Sorry, no hero here. :/");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero hero)
        {
            hero.Comic = null;

            _dbContext.Heroes.Add(hero);
            await _dbContext.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero hero)
        {
            var dbHero = await _dbContext.Heroes.FindAsync(id);

            if (dbHero == null) return NotFound("Sorry, but no hero for you :(");

            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.HeroName = hero.HeroName;
            dbHero.ComicId = hero.ComicId;
            await _dbContext.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _dbContext.Heroes.FindAsync(id);

            _dbContext.Heroes.Remove(dbHero);
            await _dbContext.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _dbContext.Comics.ToListAsync();
            return Ok(comics);
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _dbContext.Heroes.Include(x => x.Comic).ToListAsync();
        }

    }
}
