using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManagement.Data
{
    public class IMDbContext : DbContext
    {
        public IMDbContext(DbContextOptions<IMDbContext> options) : base(options)
        {

        }
        public virtual DbSet<InventoryManagement.Data.Models.Product> Product { get; set; }
        public virtual DbSet<InventoryManagement.Data.Models.ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<InventoryManagement.Data.Models.NozzleFlow> NozzleFlow { get; set; }
        public virtual DbSet<InventoryManagement.Data.Models.ProductStatus> ProductStatus { get; set; }
        public virtual DbSet<InventoryManagement.Data.Models.Mechanism> Mechanism { get; set; }
    }
}
