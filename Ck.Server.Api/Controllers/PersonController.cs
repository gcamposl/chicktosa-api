using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Application.DTOs;
using Ck.Server.Application.Services.Interfaces;
using Ck.Server.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ck.Server.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonController : ControllerBase
  {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
      _personService = personService;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
    {
      var result = await _personService.CreateAsync(personDTO);
      if (result.IsSucess)
        return Ok();

      return BadRequest(result);
    }
  }
}