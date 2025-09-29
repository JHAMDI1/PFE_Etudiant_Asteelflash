using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Services
{
    public class ActionImmediateGlobaleServices : IActionImmediateGlobaleServices
    {
        private readonly IActionImmediateGlobaleRepository _repository;
        private readonly IMapper _mapper;

        public ActionImmediateGlobaleServices(IActionImmediateGlobaleRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ActionImmediateGlobaleDto> CreateAsync(CreateActionImmediateGlobaleDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.ActionImmediateGlobale>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<ActionImmediateGlobaleDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ActionImmediateGlobaleDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActionImmediateGlobaleDto>>(list);
        }

        public async Task<ActionImmediateGlobaleDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ActionImmediateGlobaleDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateActionImmediateGlobaleDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
