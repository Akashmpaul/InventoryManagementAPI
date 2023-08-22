using InventoryManagement.Data;
using InventoryManagement.Repository.Contracts;

namespace InventoryManagement.Repository
{
    public class IMDbRepository : IIMDbRepository
    {
        private IMDbContext _imDBcontext;
        private Lazy<IProductRepository> _productRepo;
        private Lazy<IProductCategoryRepository> _categoryRepo;
        private Lazy<IProductStatusRepository> _statusRepo;
        private Lazy<IMechanismRepository> _mechanismRepo;
        private Lazy<INozzleFlowRepository> _nozzleRepo;

        public IProductRepository products
        {
            get
            {
                return _productRepo.Value;
            }
        }

        public IProductCategoryRepository category
        {
            get
            {
                return _categoryRepo.Value;
            }
        }

        public IProductStatusRepository status
        {
            get
            {
                return _statusRepo.Value;
            }
        }
        public IMechanismRepository mechanism
        {
            get
            {
                return _mechanismRepo.Value;
            }
        }
        public INozzleFlowRepository nozzle
        {
            get
            {
                return _nozzleRepo.Value;
            }
        }
        public IMDbRepository(IMDbContext repositoryContext)
        {
            _imDBcontext = repositoryContext;
            _productRepo = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _categoryRepo = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(repositoryContext));
            _statusRepo = new Lazy<IProductStatusRepository>(() => new ProductStatusRepository(repositoryContext));
            _mechanismRepo = new Lazy<IMechanismRepository>(() => new MechanismRepository(repositoryContext));
            _nozzleRepo = new Lazy<INozzleFlowRepository>(() => new NozzleFlowRepository(repositoryContext));
        }

        public async Task Save()
        {
            await _imDBcontext.SaveChangesAsync();
        }
    }
}
