using InventoryManagement.Data;
using InventoryManagement.Data.Models;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IMDbContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategory()
        {
            return await FindAll()
             .ToListAsync();
        }

        public async Task<ProductCategory> GetAllProductCategoryByID(int? id)
        {
            var category = await FindByCondition(ProductCategory => ProductCategory.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (category == null)
            {
                throw new NotFoundException($"No such contact exists in our database with id {id}");
            }
            return category;
        }
    }
}
