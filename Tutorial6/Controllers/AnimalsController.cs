using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Database.Animals);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Database.Animals.Find(animal => animal.Id == id));
        }
        
        [HttpPost]
        public IActionResult Post(Animal animal)
        {
            Database.Animals.Add(animal);
            return Ok(Database.Animals.Last());
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Animal newAnimal)
        {
            var find = Database.Animals.Find(animal => animal.Id == id);
            if (find == null)
            {
                return NotFound();
            }
            Database.Animals.Remove(find);
            Database.Animals.Add(newAnimal);
            return Ok(Database.Animals.Last());
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var find = Database.Animals.Find(animal => animal.Id == id);
            if (find == null)
            {
                return NotFound();
            }
            Database.Animals.Remove(find);
            return Ok(Database.Animals.Last());
        }
        
        [HttpGet("{name}")]
        [Route("search/{name}")]
        public IActionResult SearchAction(string name)
        {
            var foundAnimals = Database.Animals.Where(animal => animal.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!foundAnimals.Any())
            {
                return NotFound();
            }
            return Ok(foundAnimals);
        }
    }
}
