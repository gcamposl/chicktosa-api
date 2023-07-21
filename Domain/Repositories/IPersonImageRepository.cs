using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPersonImageRepository
    {
        Task<PersonImage?> GetByIdAsync(int id);
        Task<PersonImage> CreateAsync(PersonImage personImage);
        Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId);
        Task UpdateAsync(PersonImage personImage);
    }
}