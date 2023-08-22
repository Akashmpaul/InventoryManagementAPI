using InventoryManagement.Data.Models;

namespace InventoryManagement.Repository.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductByID(int id);
    }
}
