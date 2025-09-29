using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Services
{
    public class Recherche_causes_racinesD4Services : IRecherche_causes_racinesD4Services
    {
        private readonly IRecherche_causes_racinesD4Repository _repository;
        private readonly IMapper _mapper;

        public Recherche_causes_racinesD4Services(IRecherche_causes_racinesD4Repository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Recherche_causes_racinesD4Dto> CreateAsync(Recherche_causes_racinesD4Dto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.Recherche_causes_racinesD4>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<Recherche_causes_racinesD4Dto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Recherche_causes_racinesD4Dto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Recherche_causes_racinesD4Dto>>(list);
        }

        public async Task<Recherche_causes_racinesD4Dto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<Recherche_causes_racinesD4Dto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, Recherche_causes_racinesD4Dto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
