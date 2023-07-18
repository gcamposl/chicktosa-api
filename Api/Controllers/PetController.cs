using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Pet;
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
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _petService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _petService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PetDTO pet)
        {
            var result = await _petService.UpdateAsync(pet);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _petService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}