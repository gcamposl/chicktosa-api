using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PetDTO petDTO)
        {
            var result = await _petService.CreateAsync(petDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}