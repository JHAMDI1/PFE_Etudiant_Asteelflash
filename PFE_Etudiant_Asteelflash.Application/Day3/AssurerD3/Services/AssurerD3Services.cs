using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Services
{
    public class AssurerD3Services : IAssurerD3Services
    {
        private readonly IAssurerD3Repository _repository;
        private readonly IMapper _mapper;

        public AssurerD3Services(IAssurerD3Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AssurerD3Dto> CreateAsync(CreateAssurerD3Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.AssurerD3>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<AssurerD3Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<AssurerD3Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssurerD3Dto>>(list);
        }

        public async Task<AssurerD3Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<AssurerD3Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateAssurerD3Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
