using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Contracts
{
    public interface IMechanismService
    {
        Task<IEnumerable<MechanismDto>> GetAllMechanismAsync();
        Task<MechanismDto> GetMechanismByIDAsync(int id);
        Task<MechanismDto> CreateNewMechanismAsync(MechanismDto NewMechanismInfo);
        Task UpdateMechanismAsync(int id, MechanismDto UpdatedMechanismInfo);
        Task DeleteMechanismAsync(int id);
    }
}
