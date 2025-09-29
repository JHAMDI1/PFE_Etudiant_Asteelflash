using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Interfaces
{
    public interface IEquipeServices
    {
        Task<CreateEquipeDto> CreateEquipeAsync(CreateEquipeDto dto);
        Task<bool> UpdateEquipeAsync(CreateEquipeDto dto);
        Task<bool> DeleteEquipeAsync(int id);
        Task<CreateEquipeDto> GetEquipeByIdAsync(int id);
        Task<IEnumerable<CreateEquipeDto>> GetAllEquipesAsync();
    }
}
