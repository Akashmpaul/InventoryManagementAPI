using AutoMapper;
using InventoryManagement.Data.Models;
using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository.Contracts;
using InventoryManagement.Services.Contracts;

namespace InventoryManagement.Services
{
    public class ProductStatusService : IProductStatusService
    {
        private readonly IIMDbRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductStatusService(IIMDbRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductStatusDto>> GetAllProductStatusAsync()
        {
            var _status = await _repository.status.GetAllProductStatus();
            _logger.LogInfo($"Returned all contacts from database.");
            var StatusResult = _mapper.Map<IEnumerable<ProductStatusDto>>(_status);
            return StatusResult;
        }
        public async Task<ProductStatusDto> GetAllProductStatusByIDAsync(int id)
        {
            var _status = await _repository.status.GetProductStatusByID(id);

            if (_status == null)
            {
                throw new NotFoundException($"Contacts with name: {id}, hasn't been found in db.");
            }
            _logger.LogInfo($"Returned Contact details with name: {id}");

            var statusInfo = _mapper.Map<ProductStatusDto>(_status);
            return statusInfo;

        }
        public async Task<ProductStatusDto> CreateNewProductStatusAsync(ProductStatusDto NewProductStatusInfo)
        {
            var _status = _mapper.Map<ProductStatus>(NewProductStatusInfo);

            var statusId = _repository.status.FindAll().Max((ps => ps.Id));

            _repository.status.Create(_status);

            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");

            var createdStatus = _mapper.Map<ProductStatusDto>(_status);

            return createdStatus;

        }
        public async Task UpdateProductStatusAsync(int id, ProductStatusDto UpdatedProductStatusinfo)
        {
            var _status = await _repository.status.GetProductStatusByID(id);
            if (_status == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _mapper.Map(UpdatedProductStatusinfo, _status);
            _status.Id = id;
            _repository.status.Update(_status);
            _logger.LogInfo($"updated leadInfo for lead {id} in database.");


            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");
        }

        public async Task DeleteProductStatusAsync(int id)
        {
            var _status = await _repository.status.GetProductStatusByID(id);
            if (_status == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _logger.LogInfo($"Getting Related logs in database.");

            _repository.status.Delete(_status);
            _logger.LogInfo($"Deleted the lead {id} from database");

            await _repository.Save();
            _logger.LogInfo($"Commited all transactions in database.");
        }


    }
}
