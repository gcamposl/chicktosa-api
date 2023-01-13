using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IPlanService
    {
        Task<ResultService<PlanDTO>> CreateAsync(PlanDTO planDTO);
    }
}