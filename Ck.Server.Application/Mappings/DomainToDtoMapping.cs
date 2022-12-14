using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ck.Server.Application.DTOs;
using Ck.Server.Domain.Entities;

namespace Ck.Server.Application.Mappings
{
  public class DomainToDtoMapping : Profile
  {
    public DomainToDtoMapping()
    {
      CreateMap<Person, PersonDTO>();
    }
  }
}