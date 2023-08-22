using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Contracts
{
    public interface IProductStatusService
    {
        Task<IEnumerable<ProductStatusDto>> GetAllProductStatusAsync();
        Task<ProductStatusDto> GetAllProductStatusByIDAsync(int id);
        Task<ProductStatusDto> CreateNewProductStatusAsync(ProductStatusDto NewProductStatusInfo);
        Task UpdateProductStatusAsync(int id, ProductStatusDto UpdatedProductStatusinfo);
        Task DeleteProductStatusAsync(int id);
    }
}
