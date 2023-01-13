using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPetRepository _petRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPlanRepository _planRepository;

        public PlanService(IPetRepository petRepository, IPersonRepository personRepository,
                             IPlanRepository planRepository)
        {
            _petRepository = petRepository;
            _personRepository = personRepository;
            _planRepository = planRepository;
        }
        public async Task<ResultService<PlanDTO>> CreateAsync(PlanDTO planDTO)
        {
            if (planDTO == null)
                return ResultService.Fail<PlanDTO>("Plano deve ser informado!");

            var validate = new PlanDTOValidator().Validate(planDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PlanDTO>("Problemas de validação no plano!", validate);

            var petId = await _petRepository.GetIdByNameAsync(planDTO.Name);
            var personId = await _personRepository.GetIdByDocumentAsync(planDTO.Document);
            var plan = new Plan(petId, personId);
            var data = await _planRepository.CreateAsync(plan);
            planDTO.Id = data.Id;

            return ResultService.Ok<PlanDTO>(planDTO);
        }
    }
}