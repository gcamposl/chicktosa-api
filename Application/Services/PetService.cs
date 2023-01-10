using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public PetService(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PetDTO>> CreateAsync(PetDTO petDTO)
        {
            if (petDTO == null)
                return ResultService.Fail<PetDTO>("Pet deve ser informado!");

            var result = new PetDTOValidator().Validate(petDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PetDTO>("Problemas na validação", result);

            var pet = _mapper.Map<Pet>(petDTO);
            var data = await _petRepository.CreateAsync(pet);
            return ResultService.Ok<PetDTO>(_mapper.Map<PetDTO>(data));
        }

        public async Task<ResultService<ICollection<PetDTO>>> GetAsync()
        {
            var pets = await _petRepository.GetAsync();
            return ResultService.Ok<ICollection<PetDTO>>(_mapper.Map<ICollection<PetDTO>>(pets));
        }

        public async Task<ResultService<PetDTO>> GetByIdAsync(int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if (pet == null)
                return ResultService.Fail<PetDTO>("Pet não encontrado!");
            return ResultService.Ok<PetDTO>(_mapper.Map<PetDTO>(pet));
        }
    }
}