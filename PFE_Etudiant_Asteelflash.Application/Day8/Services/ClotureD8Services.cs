using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day8.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day8.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day8.Services
{
    public class ClotureD8Services : IClotureD8Services
    {
        private readonly IClotureD8Repository _repository;
        private readonly IMapper _mapper;

        public ClotureD8Services(IClotureD8Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ClotureD8Dto> CreateAsync(CreateClotureD8Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<ClotureD8>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<ClotureD8Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ClotureD8Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClotureD8Dto>>(list);
        }

        public async Task<ClotureD8Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClotureD8Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateClotureD8Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
