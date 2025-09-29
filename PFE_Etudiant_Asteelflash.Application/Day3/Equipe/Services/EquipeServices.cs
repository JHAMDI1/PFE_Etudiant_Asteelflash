using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Services
{
    public class EquipeServices : IEquipeServices
    {
        private readonly IEquipeRepository _repository;
        private readonly IMapper _mapper;

        public EquipeServices(IEquipeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateEquipeDto> CreateEquipeAsync(CreateEquipeDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.Equipe>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CreateEquipeDto>(created);
        }

        public async Task<bool> UpdateEquipeAsync(CreateEquipeDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return false;
            
            entity = _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteEquipeAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<CreateEquipeDto> GetEquipeByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CreateEquipeDto>(entity);
        }

        public async Task<IEnumerable<CreateEquipeDto>> GetAllEquipesAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CreateEquipeDto>>(list);
        }
    }
}
