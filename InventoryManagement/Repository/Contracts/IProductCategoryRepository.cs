using InventoryManagement.Data.Models;

namespace InventoryManagement.Repository.Contracts
{
    public interface IProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategory();
        Task<ProductCategory> GetAllProductCategoryByID(int? id);
    }
}
