using Data.Context;
using Domain.Entities;
using Domain.FiltersDB;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonImageRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        private PersonImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public Task DeleteAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetIdByDocumentAsync(string document)
        {
            throw new NotImplementedException();
        }

        public Task<PagedBaseReponse<Person>> GetPagedAsync(PersonFilterDb request)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Person>> GetPersonAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}