using System;
using Domain.Entities;
using Domain.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Domain.FiltersDB;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPersonAsync()
        {
            return await _db.Person.ToListAsync();
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _db.Person.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }

        public async Task<PagedBaseReponse<Person>> GetPagedAsync(PersonFilterDb request)
        {
            var person = _db.Person.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
                person = person.Where(x => x.Name.Contains(request.Name));

            return await PagedBaseResponseHelper
                .GetResponseAsync<PagedBaseReponse<Person>, Person>(person, request);
        }
    }
}