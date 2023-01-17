using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPetRepository _petRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public PlanService(IPetRepository petRepository, IPersonRepository personRepository,
                             IPlanRepository planRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _personRepository = personRepository;
            _planRepository = planRepository;
            _mapper = mapper;
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

        public async Task<ResultService<ICollection<PlanDetailDTO>>> GetAsync()
        {
            var plans = await _planRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PlanDetailDTO>>(plans));
        }

        public async Task<ResultService<PlanDetailDTO>> GetByIdAsync(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            if (plan == null)
                return ResultService.Fail<PlanDetailDTO>($"Plano com id:{id} não existe!");
            return ResultService.Ok(_mapper.Map<PlanDetailDTO>(plan));
        }
    }
}