using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetAllProductByIDAsync(int id);
        Task<ProductDto> CreateNewProductAsync(ProductDto NewProductInfo);
        Task UpdateProductAsync(int id, ProductDto UpdatedProductinfo);
        Task DeleteProductAsync(int id);
    }
}
