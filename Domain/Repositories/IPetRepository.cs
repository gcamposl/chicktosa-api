using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPetRepository
    {
        Task<Pet> GetByIdAsync(int id);
        Task<ICollection<Pet>> GetAsync();
        Task<Pet> CreateAsync(Pet pet);
        Task UpdateAsync(Pet pet);
        Task DeleteAsync(Pet pet);
        Task<int> GetIdByNameAsync(string name);
    }
}