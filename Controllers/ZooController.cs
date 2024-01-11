using Microsoft.AspNetCore.Mvc;
using Zoo.Dtos;
using Zoo.Services;
using Zoo.Services.Interfaces;

namespace Zoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private readonly IEnclosureService _enclosureService;

        public ZooController(IEnclosureService enclosureService)
        {
            _enclosureService = enclosureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetZooStructure()
        {
            return Ok(await _enclosureService.GetEnclosuresWithAnimals());
        }
    }
}