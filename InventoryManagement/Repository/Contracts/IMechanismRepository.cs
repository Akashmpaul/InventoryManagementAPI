using InventoryManagement.Data.Models;

namespace InventoryManagement.Repository.Contracts
{
   
        public interface IMechanismRepository : IRepositoryBase<Mechanism>
        {
            Task<IEnumerable<Mechanism>> GetAllMechanism();
            Task<Mechanism> GetMechanismByID(int id);
        }
    
}