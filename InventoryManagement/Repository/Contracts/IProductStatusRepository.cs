using InventoryManagement.Data.Models;

namespace InventoryManagement.Repository.Contracts
{
    public interface IProductStatusRepository : IRepositoryBase<ProductStatus>
    {
        Task<IEnumerable<ProductStatus>> GetAllProductStatus();

        Task<ProductStatus> GetProductStatusByID(int id);
    }
}
