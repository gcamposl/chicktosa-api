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
        Task<ResultService<PlanDetailDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PlanDetailDTO>>> GetAsync();
        Task<ResultService<PlanDTO>> UpdateAsync(PlanDTO planDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}