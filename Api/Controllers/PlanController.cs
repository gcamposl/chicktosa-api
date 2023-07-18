using System.Net;
using Application.DTOs;
using Application.DTOs.Plan;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PlanDTO planDTO)
        {
            try
            {
                var result = await _planService.CreateAsync(planDTO);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _planService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _planService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PlanDTO planDTO)
        {
            try
            {
                var result = await _planService.UpdateAsync(planDTO);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _planService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}