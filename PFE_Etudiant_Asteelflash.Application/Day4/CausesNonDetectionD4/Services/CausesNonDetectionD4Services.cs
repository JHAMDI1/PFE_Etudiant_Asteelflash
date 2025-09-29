using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using DomainCausesNonDetectionD4 = PFE_Etudiant_Asteelflash.Domain.Entities.CausesNonDetectionD4;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Services
{
    public class CausesNonDetectionD4Services : ICausesNonDetectionD4Services
    {
        private readonly ICausesNonDetectionD4Repository _repository;
        private readonly IMapper _mapper;

        public CausesNonDetectionD4Services(ICausesNonDetectionD4Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CausesNonDetectionD4Dto> CreateAsync(CreateCausesNonDetectionD4Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<DomainCausesNonDetectionD4>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CausesNonDetectionD4Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<CausesNonDetectionD4Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CausesNonDetectionD4Dto>>(list);
        }

        public async Task<CausesNonDetectionD4Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CausesNonDetectionD4Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateCausesNonDetectionD4Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
