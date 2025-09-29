using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day6.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day6.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day6.Services
{
    public class SuiviD6Services : ISuiviD6Services
    {
        private readonly ISuiviD6Repository _repository;
        private readonly IMapper _mapper;

        public SuiviD6Services(ISuiviD6Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SuiviD6Dto> CreateAsync(CreateSuiviD6Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<SuiviD6>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<SuiviD6Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<SuiviD6Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SuiviD6Dto>>(list);
        }

        public async Task<SuiviD6Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SuiviD6Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateSuiviD6Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
