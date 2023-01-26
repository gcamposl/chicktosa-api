using System;
using Domain.Entities;
using Domain.FiltersDB;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetPersonAsync();
        Task<Person> CreateAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
        Task<int> GetIdByDocumentAsync(string document);
        Task<PagedBaseReponse<Person>> GetPagedAsync(PersonFilterDb request);
    }
}