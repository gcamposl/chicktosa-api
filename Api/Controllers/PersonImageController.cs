using Application.DTOs.PersonImage;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class PersonImageController : ControllerBase
    {
        private readonly IPersonImageService _personImageService;

        public PersonImageController(IPersonImageService personImageService)
        {
            this._personImageService = personImageService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveImage(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageBase64Async(personImageDTO);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result);
        }
    }
}