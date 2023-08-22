using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Contracts
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryDto>> GetAllProductCategoryAsync();
        Task<ProductCategoryDto> GetAllProductCategoryByIDAsync(int id);
        Task<ProductCategoryDto> CreateNewProductCategoryAsync(ProductCategoryDto NewCategoryInfo);
        Task UpdateProductCategoryAsync(int id, ProductCategoryDto UpdatedProductCategoryinfo);
       // Task DeleteProductCategoryAsync(int id);
    }
}
