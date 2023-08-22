using InventoryManagement.Data.Models;

namespace InventoryManagement.Repository.Contracts
{
    public interface IMechanismRepository
    {
        public interface IMechanismRepository : IRepositoryBase<Mechanism>
        {
            Task<IEnumerable<Mechanism>> GetAllMechanism();


        }
    }
}