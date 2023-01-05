using AutoMapper;
using Application.DTOs;
using Domain.Entities;

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