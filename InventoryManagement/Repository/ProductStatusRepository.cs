using InventoryManagement.Data;
using InventoryManagement.Data.Models;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class ProductStatusRepository : RepositoryBase<ProductStatus>, IProductStatusRepository
    {
        public ProductStatusRepository(IMDbContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ProductStatus>> GetAllProductStatus()
        {
            return await FindAll()
             .ToListAsync();
        }

        public async Task<ProductStatus> GetProductStatusByID(int id)
        {
            var status = await FindByCondition(ProductStatus => ProductStatus.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (status == null)
            {
                throw new NotFoundException($"No such contact exists in our database with id {id}");
            }
            return status;
        }
    }
}
