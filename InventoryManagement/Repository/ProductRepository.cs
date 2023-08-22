using InventoryManagement.Data;
using InventoryManagement.Data.Models;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IMDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            // Gets Lead Details along with contact details
            return await FindAll()
                .Include(pc => pc.Category)
                .Include(ps => ps.Status)
                .ToListAsync();
        }

        public async Task<Product> GetProductByID(int id)
        {
            var product = await FindByCondition(Product => Product.Id.Equals(id))
                .Include(pc => pc.Category)
                .Include(ps => ps.Status)
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new NotFoundException($"There is no such lead exists in our database with Id {id}");
            }
            return product;
        }
    }
}
