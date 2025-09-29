using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Services
{
    public class QuantitéTriéeParJourServices : IQuantitéTriéeParJourServices
    {
        private readonly IQuantitéTriéeParJourRepository _repository;
        private readonly IMapper _mapper;

        public QuantitéTriéeParJourServices(IQuantitéTriéeParJourRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<QuantitéTriéeParJourDto> CreateAsync(CreateQuantitéTriéeParJourDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.QuantitéTriéeParJour>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<QuantitéTriéeParJourDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<QuantitéTriéeParJourDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuantitéTriéeParJourDto>>(list);
        }

        public async Task<QuantitéTriéeParJourDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<QuantitéTriéeParJourDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateQuantitéTriéeParJourDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
