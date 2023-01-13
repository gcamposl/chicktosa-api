using Application.DTOs;
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
                if (result.IsSucess)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }
    }
}