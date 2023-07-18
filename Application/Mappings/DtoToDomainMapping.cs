using AutoMapper;
using Domain.Entities;
using Application.DTOs.Person;
using Application.DTOs.Pet;

namespace Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<PetDTO, Pet>();
        }
    }
}