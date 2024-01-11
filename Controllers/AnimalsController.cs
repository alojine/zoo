using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.Dtos;
using Zoo.Services.Interfaces;

namespace Zoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        public async Task<IActionResult> AccomodateAnimals([FromBody] AnimalWrapperDto animalWrapperDto)
        {
            if (animalWrapperDto == null || animalWrapperDto.animals == null)
            {
                return BadRequest("Invalid data of animals provided");
            }
            
            await _animalService.AccomodateAnimals(animalWrapperDto.animals);

            return Ok();
        }
    }
}
