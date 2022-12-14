using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Application.DTOs;

namespace Ck.Server.Application.Services.Interfaces
{
  public interface IPersonService
  {
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
  }
}