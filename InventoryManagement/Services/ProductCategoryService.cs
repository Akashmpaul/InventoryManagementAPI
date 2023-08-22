using AutoMapper;
using InventoryManagement.Data.Models;
using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository.Contracts;
using InventoryManagement.Services.Contracts;

namespace InventoryManagement.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IIMDbRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductCategoryService(IIMDbRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAllProductCategoryAsync()
        {
            var _category = await _repository.category.GetAllProductCategory();
            _logger.LogInfo($"Returned all contacts from database.");
            var categoryResult = _mapper.Map<IEnumerable<ProductCategoryDto>>(_category);
            return categoryResult;
        }
        public async Task<ProductCategoryDto> GetAllProductCategoryByIDAsync(int id)
        {
            var _category = await _repository.category.GetAllProductCategoryByID(id);

            if (_category == null)
            {
                throw new NotFoundException($"Contacts with name: {id}, hasn't been found in db.");
            }
            _logger.LogInfo($"Returned Contact details with name: {id}");

            var categoryInfo = _mapper.Map<ProductCategoryDto>(_category);
            return categoryInfo;

        }
        public async Task<ProductCategoryDto> CreateNewProductCategoryAsync(ProductCategoryDto NewCategoryInfo)
        {
            var _category = _mapper.Map<ProductCategory>(NewCategoryInfo);

            var _categoryId = _repository.category.FindAll().Max((pc => pc.Id));

            _repository.category.Create(_category);

            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");

            var createdCategory = _mapper.Map<ProductCategoryDto>(_category);

            return createdCategory;

        }
        public async Task UpdateProductCategoryAsync(int id, ProductCategoryDto UpdatedProductCategoryinfo)
        {
            var _category = await _repository.category.GetAllProductCategoryByID(id);
            if (_category == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _mapper.Map(UpdatedProductCategoryinfo, _category);
            _category.Id = id;
            _repository.category.Update(_category);
            _logger.LogInfo($"updated leadInfo for lead {id} in database.");


            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            var _category = await _repository.category.GetAllProductCategoryByID(id);
            if (_category == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _logger.LogInfo($"Getting Related logs in database.");

            _repository.category.Delete(_category);
            _logger.LogInfo($"Deleted the lead {id} from database");

            await _repository.Save();
            _logger.LogInfo($"Commited all transactions in database.");
        }


    }
}
