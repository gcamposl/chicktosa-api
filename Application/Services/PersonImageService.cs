using Application.DTOs.PersonImage;
using Application.DTOs.PersonImage.Validations;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Integrations;
using Domain.Repositories;

namespace Application.Services
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonImageRepository _personImageRepository;
        private readonly ISavePersonImage _savePersonImage;

        public PersonImageService(
            IPersonRepository personRepository,
            IPersonImageRepository personImageRepository,
            ISavePersonImage savePersonImage)
        {
            _personRepository = personRepository;
            _personImageRepository = personImageRepository;
            _savePersonImage = savePersonImage;
        }

        public async Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO)
        {
            if (personImageDTO is null)
                return ResultService.Fail("Objeto deve ser informado.");

            var validations = new PersonImageDTOValidation().Validate(personImageDTO);
            if (!validations.IsValid)
                return ResultService.RequestError("Erro na validação do objeto.", validations);

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);
            if (person is null)
                return ResultService.Fail($"Pessoa {personImageDTO.PersonId} não foi encontrada");

            var pathImage = _savePersonImage.Save(personImageDTO.Image);
            var personImage = new PersonImage(person.Id, pathImage, null);
            await _personImageRepository.CreateAsync(personImage);

            return ResultService.Ok("Imagem salva!");
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