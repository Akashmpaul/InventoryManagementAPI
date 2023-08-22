using AutoMapper;
using InventoryManagement.Data.Models;
using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository.Contracts;
using InventoryManagement.Services.Contracts;

namespace InventoryManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IIMDbRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductService(IIMDbRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var _product = await _repository.products.GetAllProduct();
            _logger.LogInfo($"Returned all Lead information from database.");
            var _productResult = _mapper.Map<IEnumerable<ProductDto>>(_product);
            return _productResult;
        }

        public async Task<ProductDto> GetAllProductByIDAsync(int id)
        {
            var _product = await _repository.products.GetProductByID(id);
            if (_product is null)
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");

            var productResult = _mapper.Map<ProductDto>(_product);
            _logger.LogInfo($"Returned requested Lead information from database.");

            return productResult;
        }
        public async Task<ProductDto> CreateNewProductAsync(ProductDto NewProductInfo)
        {
            var _product = _mapper.Map<Product>(NewProductInfo);

            //var LatestId = _repository.bookings.FindAll().Max((p => p.OrderNo)); 
            _repository.products.Create(_product);

            var createdLead = _mapper.Map<ProductDto>(_product);

            await _repository.Save();

            return createdLead;

        }
        public async Task DeleteProductAsync(int id)
        {
            var _product = await _repository.products.GetProductByID(id);
            if (_product == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _logger.LogInfo($"Getting Related logs in database.");

            _repository.products.Delete(_product);
            _logger.LogInfo($"Deleted the lead {id} from database");

            await _repository.Save();
            _logger.LogInfo($"Commited all transactions in database.");
        }

        public async Task UpdateProductAsync(int id, ProductDto UpdatedProductinfo)
        {
            var _product = await _repository.products.GetProductByID(id);
            if (_product == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _mapper.Map(UpdatedProductinfo, _product);
            _product.Id = id;
            _repository.products.Update(_product);
            _logger.LogInfo($"updated leadInfo for lead {id} in database.");


            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");
        }
    }
}
