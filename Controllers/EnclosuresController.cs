using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.Dtos;
using Zoo.Services;
using Zoo.Services.Interfaces;

namespace Zoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosuresController : ControllerBase
    {
        private readonly IEnclosureService _enclosureService;

        public EnclosuresController(IEnclosureService enclosureService)
        {
            _enclosureService = enclosureService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnclosures([FromBody] EnclosuresWrapperDto enclosuresWrapperDto)
        {
            if (enclosuresWrapperDto == null || enclosuresWrapperDto.enclosures == null)
            {
                return BadRequest("Invalid data");
            }

            var flattenedEnclosures = enclosuresWrapperDto.enclosures.Select(x => x).ToList();

            await _enclosureService.SaveEnclosures(flattenedEnclosures);
            return CreatedAtAction(nameof(CreateEnclosures), enclosuresWrapperDto);
        }
    }
}
