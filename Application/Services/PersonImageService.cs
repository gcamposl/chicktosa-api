using Application.DTOs.PersonImage;
using Application.DTOs.PersonImage.Validations;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonImageRepository _personImageRepository;

        public PersonImageService(IPersonRepository personRepository, IPersonImageRepository personImageRepository)
        {
            _personRepository = personRepository;
            _personImageRepository = personImageRepository;
        }

        public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
                return ResultService.Fail("Objeto personImage deve ser informado!");

            var validations = new PersonImageDTOValidation().Validate(personImageDTO);

            if (!validations.IsValid)
                return ResultService.RequestError("Problema de validação!", validations);

            var person = _personRepository.GetByIdAsync(personImageDTO.PersonId);

            if (person == null)
                return ResultService.Fail("Id da pessoa não encontrado");

            var personImage = new PersonImage(person.Id, null, personImageDTO.Image);
            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem em base64 salva");
        }
    }
}