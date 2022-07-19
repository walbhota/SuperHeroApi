using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>   
         {
             new SuperHero {
                    Id = 1,
                    Name = "Super Man",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "Metropolis"
            },

             new SuperHero {
                    Id = 2,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
            },

             new SuperHero {
                    Id = 3,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long Island"
            },

             new SuperHero
             {
                 Id = 4,
                 Name = "Doctor Strange",
                 FirstName = "Stephen",
                 LastName = "Strange",
                 Place = "New York City"
             }
        };


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null || hero.Id == 0)
                return BadRequest("Hero you're trying to update, not found");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("The Hero you're trying to delete is not found");

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
