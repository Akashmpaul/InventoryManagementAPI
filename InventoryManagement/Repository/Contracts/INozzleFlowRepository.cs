using InventoryManagement.Data.Models;

namespace InventoryManagement.Repository.Contracts
{
    public interface INozzleFlowRepository
    {
        public interface INozzleFlowRepository : IRepositoryBase<NozzleFlow>
        {
            Task<IEnumerable<NozzleFlow>> GetAllNozzleFlow();

            Task<NozzleFlow> GetNozzleFlowByID(int id);
        }
    }
}
