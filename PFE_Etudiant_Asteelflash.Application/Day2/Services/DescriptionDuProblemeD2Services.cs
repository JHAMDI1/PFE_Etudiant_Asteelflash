using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day2.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day2.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day2.Services
{
    public class DescriptionDuProblemeD2Services : IDescriptionDuProblemeD2Services
    {
        private readonly IDescriptionDuProblemeD2Repository _repository;
        private readonly IMapper _mapper;

        public DescriptionDuProblemeD2Services(IDescriptionDuProblemeD2Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DescriptionDuProblemeD2Dto> CreateAsync(CreateDescriptionDuProblemeD2Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<DescriptionDuProblemeD2>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<DescriptionDuProblemeD2Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<DescriptionDuProblemeD2Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DescriptionDuProblemeD2Dto>>(list);
        }

        public async Task<DescriptionDuProblemeD2Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<DescriptionDuProblemeD2Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateDescriptionDuProblemeD2Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
