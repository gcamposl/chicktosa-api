using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Domain.Entities;

namespace Ck.Server.Domain.Repositories
{
  public interface IPlanRepository
  {
    Task<Plan> CreateAsync(Plan plan);
    Task DeleteAsync(Plan plan);
    Task UpdateAsync(Plan plan);
    Task<Plan> GetByIdAsync(int id);
    Task<ICollection<Plan>> GetByPersonIdAsync(int personId);
    Task<ICollection<Plan>> GetByPetIdAsync(int petId);
    Task<ICollection<Plan>> GetAllAsync();
  }
}