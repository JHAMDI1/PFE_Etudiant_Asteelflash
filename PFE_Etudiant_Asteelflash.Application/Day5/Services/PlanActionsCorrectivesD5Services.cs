using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day5.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day5.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day5.Services
{
    public class PlanActionsCorrectivesD5Services : IPlanActionsCorrectivesD5Services
    {
        private readonly IPlanActionsCorrectivesD5Repository _repository;
        private readonly IMapper _mapper;

        public PlanActionsCorrectivesD5Services(IPlanActionsCorrectivesD5Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PlanActionsCorrectivesD5Dto> CreateAsync(CreatePlanActionsCorrectivesD5Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PlanActionsCorrectivesD5>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<PlanActionsCorrectivesD5Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<PlanActionsCorrectivesD5Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlanActionsCorrectivesD5Dto>>(list);
        }

        public async Task<PlanActionsCorrectivesD5Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<PlanActionsCorrectivesD5Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreatePlanActionsCorrectivesD5Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
