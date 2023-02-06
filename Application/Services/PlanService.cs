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
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IPetRepository petRepository, IPersonRepository personRepository,
                             IPlanRepository planRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _personRepository = personRepository;
            _planRepository = planRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultService<PlanDTO>> CreateAsync(PlanDTO planDTO)
        {
            if (planDTO == null)
                return ResultService.Fail<PlanDTO>("Plano deve ser informado!");

            var validate = new PlanDTOValidator().Validate(planDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PlanDTO>("Problemas de validação no plano!", validate);

            var petId = await _petRepository.GetIdByNameAsync(planDTO.Name);
            if (petId == 0)
            {
                // cadastrar novo pet com as informacoes da dto.
            }
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
                return ResultService.Fail<PlanDetailDTO>($"Plano com id:{id} inexistente!");
            return ResultService.Ok(_mapper.Map<PlanDetailDTO>(plan));
        }

        public async Task<ResultService<PlanDTO>> UpdateAsync(PlanDTO planDTO)
        {
            if (planDTO == null)
                return ResultService.Fail<PlanDTO>("Plano inexistente");

            var validation = new PlanDTOValidator().Validate(planDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<PlanDTO>("Erro na validação do Plano!", validation);

            var plan = await _planRepository.GetByIdAsync(planDTO.Id);
            if (plan == null)
                return ResultService.Fail<PlanDTO>($"Plano de id: {planDTO.Id} inexistente!");

            var petId = await _petRepository.GetIdByNameAsync(planDTO.Name);
            var personId = await _personRepository.GetIdByDocumentAsync(planDTO.Document);

            plan.Edit(plan.Id, petId, personId);
            await _planRepository.UpdateAsync(plan);
            return ResultService.Ok(planDTO);
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            if (plan == null)
                return ResultService.Fail($"Plano de id: {id} é inexistente!");

            await _planRepository.DeleteAsync(plan);
            return ResultService.Ok($"Plano de id: {id} foi deletado!");
        }
    }
}