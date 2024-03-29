using AutoMapper;
using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Domain.FiltersDB;
using Application.DTOs.Person;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problema de validade!", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var person = await _personRepository.GetPersonAsync();
            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(person));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail<PersonDTO>("Pessoa inexistente");
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validation = new PersonDTOValidator().Validate(personDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos!", validation);

            var person = await _personRepository.GetByIdAsync(personDTO.Id);
            if (person == null)
                return ResultService.Fail("Pessoa inexistente!");

            person = _mapper.Map<PersonDTO, Person>(personDTO, person);
            await _personRepository.UpdateAsync(person);
            return ResultService.Ok("Pessoa editada!");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail("Pessoa inexistente!");
            await _personRepository.DeleteAsync(person);
            return ResultService.Ok($"Pessoa com id:{id} deletada com sucesso!");

        }

        public async Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb)
        {
            var personPaged = await _personRepository.GetPagedAsync(personFilterDb);
            var personMap = _mapper.Map<List<PersonDTO>>(personPaged.Data);
            var result = new PagedBaseResponseDTO<PersonDTO>(personPaged.TotalRegisters, personMap);

            return ResultService.Ok(result);
        }
    }
}