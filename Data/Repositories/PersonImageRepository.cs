using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Data.Context;
using Domain.Entities;
using Domain.FiltersDB;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonImageRepository : IPersonImageRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PersonImage> CreateAsync(PersonImage personImage)
        {
            _db.Add(personImage);
            await _db.SaveChangesAsync();
            return personImage;
        }

        public async Task UpdateAsync(PersonImage personImage)
        {
            _db.Update(personImage);
            await _db.SaveChangesAsync();
        }

        public async Task<PersonImage?> GetByIdAsync(int id)
        {
            return await _db.PersonImages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId)
        {
            return await _db.PersonImages.AsNoTracking().Where(x => x.PersonId == personId).ToListAsync();
        }
    }
}