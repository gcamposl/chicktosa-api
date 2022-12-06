using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Domain.Entities;

namespace Ck.Server.Domain.Repositories
{
  public interface IPetRepository
  {
    Task<Pet> GetByIdAsync(int id);
    Task<ICollection<Pet>> GetAsync();
    Task<Pet> CreateAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(Pet pet);
  }
}