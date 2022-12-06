using System;
using Ck.Server.Domain.Entities;

namespace Ck.Server.Domain.Repositories
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