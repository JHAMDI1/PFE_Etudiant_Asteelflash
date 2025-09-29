using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Services
{
    public class ContenirD3Services : IContenirD3Services
    {
        private readonly IContenirD3Repository _repository;
        private readonly IMapper _mapper;

        public ContenirD3Services(IContenirD3Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContenirD3Dto> CreateAsync(CreateContenirD3Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.ContenirD3>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<ContenirD3Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ContenirD3Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContenirD3Dto>>(list);
        }

        public async Task<ContenirD3Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ContenirD3Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateContenirD3Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
