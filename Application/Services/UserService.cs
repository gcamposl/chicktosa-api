using Application.DTOs.User;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using Domain.Authentication;
using Domain.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("");

            var validator = new UserDTOValidator().Validate(userDTO);
            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas com a validação de usuário!", validator);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            if (user == null)
                return ResultService.Fail<dynamic>("Usuário ou senha não encontrados!");

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}