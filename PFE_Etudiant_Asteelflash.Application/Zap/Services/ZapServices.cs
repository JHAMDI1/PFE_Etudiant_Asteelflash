using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Zap.Dtos;
using PFE_Etudiant_Asteelflash.Application.Zap.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_Etudiant_Asteelflash.Application.Zap.Services
{
    public class ZapServices : IZapServices
    {
        private readonly IZapRepository _zapRepository;
        private readonly IMapper _mapper;

        public ZapServices(IZapRepository zapRepository, IMapper mapper)
        {
            _zapRepository = zapRepository ?? throw new ArgumentNullException(nameof(zapRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ZapDto> CreateZapAsync(CreateZapDto createZapDto)
        {
            var zapEntity = _mapper.Map<Domain.Entities.Zap>(createZapDto);
            var result = await _zapRepository.AddAsync(zapEntity);
            return _mapper.Map<ZapDto>(result);
        }

        public async Task<bool> DeleteZapAsync(int id)
        {
            var zapEntity = await _zapRepository.GetByIdAsync(id);
            if (zapEntity == null)
                return false;

            await _zapRepository.DeleteAsync(zapEntity);
            return true;
        }

        public async Task<IEnumerable<ZapListItemDto>> GetAllZapsAsync()
        {
            var zaps = await _zapRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ZapListItemDto>>(zaps);
        }

        public async Task<IEnumerable<ZapListItemDto>> GetAllZapsWithDetailsAsync()
        {
            // This would typically involve more complex queries with includes
            var zaps = await _zapRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ZapListItemDto>>(zaps);
        }

        // La pagination a été supprimée

        public async Task<ZapDto> GetZapByIdAsync(int id)
        {
            var zapEntity = await _zapRepository.GetByIdAsync(id);
            return _mapper.Map<ZapDto>(zapEntity);
        }

        public async Task<ZapDetailDto> GetZapByIdWithDetailsAsync(int id)
        {
            var zapEntity = await _zapRepository.GetByIdAsync(id);
            if (zapEntity == null)
                return null;

            // In a real implementation, you would include related entities
            return _mapper.Map<ZapDetailDto>(zapEntity);
        }

        public async Task<IEnumerable<ZapListItemDto>> SearchZapsAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return await GetAllZapsAsync();

            var zaps = await _zapRepository.GetAllAsync();
            var filteredZaps = zaps.Where(z => 
                z.Name.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<ZapListItemDto>>(filteredZaps);
        }

        public async Task<bool> UpdateZapAsync(UpdateZapDto updateZapDto)
        {
            var zapEntity = await _zapRepository.GetByIdAsync(updateZapDto.Id);
            if (zapEntity == null)
                return false;

            _mapper.Map(updateZapDto, zapEntity);
            await _zapRepository.UpdateAsync(zapEntity);
            return true;
        }
    }
}
