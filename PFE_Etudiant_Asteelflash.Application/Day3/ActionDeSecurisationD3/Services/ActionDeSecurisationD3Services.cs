using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Services
{
    public class ActionDeSecurisationD3Services : IActionDeSecurisationD3Services
    {
        private readonly IActionDeSecurisationD3Repository _repository;
        private readonly IMapper _mapper;

        public ActionDeSecurisationD3Services(IActionDeSecurisationD3Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ActionDeSecurisationD3Dto> CreateAsync(CreateActionDeSecurisationD3Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.ActionDeSecurisationD3>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<ActionDeSecurisationD3Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ActionDeSecurisationD3Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActionDeSecurisationD3Dto>>(list);
        }

        public async Task<ActionDeSecurisationD3Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ActionDeSecurisationD3Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateActionDeSecurisationD3Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
