using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Contracts
{
    public interface INozzleFlowService
    {
        Task<IEnumerable<NozzleFlowDto>> GetAllNozzleFlowAsync();
        Task<NozzleFlowDto> GetNozzleFlowByIDAsync(int id);
        Task<NozzleFlowDto> CreateNewNozzleFlowAsync(NozzleFlowDto NewNozzleFlowInfo);
        Task UpdateNozzleFlowAsync(int id, NozzleFlowDto UpdatedNozzleFlowInfo);
       // Task DeleteNozzleFlowAsync(int id);
    }
}
