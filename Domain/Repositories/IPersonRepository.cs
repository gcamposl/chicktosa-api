using System;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetPersonAsync();
        Task<Person> CreateAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
    }
}