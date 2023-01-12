using Domain.Entities;
using Domain.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _db;
        public PetRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Pet> CreateAsync(Pet pet)
        {
            _db.Add(pet);
            await _db.SaveChangesAsync();
            return pet;
        }

        public async Task UpdateAsync(Pet pet)
        {
            _db.Update(pet);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pet pet)
        {
            _db.Remove(pet);
            await _db.SaveChangesAsync();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            return await _db.Pet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Pet>> GetAsync()
        {
            return await _db.Pet.ToListAsync();
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            return (await _db.Pet.FirstOrDefaultAsync(x => x.Name == name))?.Id ?? 0;
        }
    }
}