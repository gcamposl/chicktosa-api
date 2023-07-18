using Application.DTOs.Pet;

namespace Application.Services.Interfaces
{
    public interface IPetService
    {
        Task<ResultService<PetDTO>> CreateAsync(PetDTO petDTO);
        Task<ResultService<ICollection<PetDTO>>> GetAsync();
        Task<ResultService<PetDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PetDTO petDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}