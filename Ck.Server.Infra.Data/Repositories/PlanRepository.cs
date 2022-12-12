using Ck.Server.Domain.Entities;
using Ck.Server.Domain.Repositories;
using Ck.Server.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ck.Server.Infra.Data.Repositories
{
  public class PlanRepository : IPlanRepository
  {
    private readonly ApplicationDbContext _db;
    public PlanRepository(ApplicationDbContext db)
    {
      _db = db;
    }

    public async Task<Plan> CreateAsync(Plan plan)
    {
      _db.Add(plan);
      await _db.SaveChangesAsync();
      return plan;
    }

    public async Task DeleteAsync(Plan plan)
    {
      _db.Remove(plan);
      await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Plan plan)
    {
      _db.Update(plan);
      await _db.SaveChangesAsync();
    }

    public async Task<Plan> GetByIdAsync(int id)
    {
      var plan = await _db.Plan
        .Include(x => x.Person)
        .Include(x => x.Pet)
        .FirstOrDefaultAsync(x => x.Id == id);

      return plan;
    }

    public async Task<ICollection<Plan>> GetByPersonIdAsync(int personId)
    {
      return await _db.Plan
        .Include(x => x.Person)
        .Include(x => x.Pet)
        .Where(x => x.PersonId == personId).ToListAsync();
    }

    public async Task<ICollection<Plan>> GetByPetIdAsync(int petId)
    {
      return await _db.Plan
        .Include(x => x.Person)
        .Include(x => x.Pet)
        .Where(x => x.PetId == petId).ToListAsync();
    }

    public async Task<ICollection<Plan>> GetAllAsync()
    {
      return await _db.Plan
        .Include(x => x.Person)
        .Include(x => x.Pet)
        .ToListAsync();
    }
  }
}