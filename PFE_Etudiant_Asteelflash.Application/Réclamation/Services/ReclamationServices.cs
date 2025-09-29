using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Dtos;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;

namespace PFE_Etudiant_Asteelflash.Application.Réclamation.Services
{
    public class ReclamationServices : IReclamationServices
    {
        private readonly IRéclamationRepository _repository;
        private readonly IMapper _mapper;
        private readonly PFE_Etudiant_Asteelflash.Domain.Interfaces.External.INotificationService _notifications;

        public ReclamationServices(IRéclamationRepository repository, IMapper mapper, PFE_Etudiant_Asteelflash.Domain.Interfaces.External.INotificationService notifications)
        {
            _repository = repository;
            _mapper = mapper;
            _notifications = notifications;
        }

        public async Task<ReclamationDto> CreateAsync(CreateReclamationDto dto)
        {
            var entity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.Réclamation>(dto);
            var created = await _repository.AddAsync(entity);
            await _notifications.SendReclamationCreatedAsync(created.Id);
            return _mapper.Map<ReclamationDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ReclamationDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReclamationDto>>(list);
        }

        public async Task<ReclamationDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReclamationDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreateReclamationDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
