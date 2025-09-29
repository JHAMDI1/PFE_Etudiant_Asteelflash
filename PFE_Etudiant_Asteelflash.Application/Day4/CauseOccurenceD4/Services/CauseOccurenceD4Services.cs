using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using DomainCauseOccurenceD4 = PFE_Etudiant_Asteelflash.Domain.Entities.CauseOccurenceD4;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Services
{
    public class CauseOccurenceD4Services : ICauseOccurenceD4Services
    {
        private readonly ICauseOccurenceD4Repository _repository;
        private readonly IMapper _mapper;

        public CauseOccurenceD4Services(ICauseOccurenceD4Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CauseOccurenceD4Dto> CreateAsync(CreateCauseOccurenceD4Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<DomainCauseOccurenceD4>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CauseOccurenceD4Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<CauseOccurenceD4Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CauseOccurenceD4Dto>>(list);
        }

        public async Task<CauseOccurenceD4Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CauseOccurenceD4Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateCauseOccurenceD4Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
