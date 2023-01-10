using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IPetService
    {
        Task<ResultService<PetDTO>> CreateAsync(PetDTO petDTO);

    }
}