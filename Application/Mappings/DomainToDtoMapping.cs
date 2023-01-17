using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Pet, PetDTO>();
            CreateMap<Plan, PlanDetailDTO>()
                .ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Pet, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PlanDetailDTO
                    {
                        Id = model.Id,
                        Pet = model.Pet.Name,
                        Person = model.Person.Name,
                        Date = model.Maturity
                    };
                    return dto;
                });
        }
    }
}