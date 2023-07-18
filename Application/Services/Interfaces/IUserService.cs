using Application.DTOs.User;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO);
    }
}