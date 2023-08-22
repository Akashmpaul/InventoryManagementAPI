using AutoMapper;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository.Contracts;
using InventoryManagement.Services.Contracts;

namespace InventoryManagement.Services
{
    public class ServiceManager : IServiceManager
    {
        private Lazy<IProductService> _productService;
        private Lazy<IProductCategoryService> _categoryService;
        private Lazy<IProductStatusService> _statusService;
        private Lazy<IMechanismService> _mechanismService;
        private Lazy<INozzleFlowService> _nozzleService;

        public IProductService Product
        {
            get
            {
                return _productService.Value;
            }
        }

        public IProductCategoryService Category
        {
            get
            {
                return _categoryService.Value;
            }
        }

        public IProductStatusService Status
        {
            get
            {
                return _statusService.Value;
            }
        }
        public IMechanismService Mechanism
        {
            get
            {
                return _mechanismService.Value;
            }
        }
        public INozzleFlowService NozzleFlow
        {
            get
            {
                return _nozzleService.Value;
            }
        }
        public ServiceManager(IIMDbRepository repository, ILoggerManager logger, IMapper mapper, IConfiguration configuration)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(repository, logger, mapper));
            _categoryService = new Lazy<IProductCategoryService>(() => new ProductCategoryService(repository, logger, mapper));
            _statusService = new Lazy<IProductStatusService>(() => new ProductStatusService(repository, logger, mapper));
            _mechanismService = new Lazy<IMechanismService>(() => new MechanismService(repository, logger, mapper));
            _nozzleService = new Lazy<INozzleFlowService>(() => new NozzleFlowService(repository, logger, mapper));
        }
    }
}
