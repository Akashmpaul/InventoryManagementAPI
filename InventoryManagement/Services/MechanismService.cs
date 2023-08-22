using AutoMapper;
using InventoryManagement.Data.Models;
using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository.Contracts;
using InventoryManagement.Services.Contracts;

namespace InventoryManagement.Services
{
    public class MechanismService : IMechanismService
    {
        private readonly IIMDbRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MechanismService(IIMDbRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MechanismDto>> GetAllMechanismAsync()
        {
            var _mechanism = await _repository.mechanism.GetAllMechanism();
            _logger.LogInfo($"Returned all contacts from database.");
            var mechanismResult = _mapper.Map<IEnumerable<MechanismDto>>(_mechanism);
            return mechanismResult;
        }
        public async Task<MechanismDto> GetMechanismByIDAsync(int id)
        {
            var _mechanism = await _repository.mechanism.GetMechanismByID(id);

            if (_mechanism == null)
            {
                throw new NotFoundException($"Contacts with name: {id}, hasn't been found in db.");
            }
            _logger.LogInfo($"Returned Contact details with name: {id}");

            var mechanismInfo = _mapper.Map<MechanismDto>(_mechanism);
            return mechanismInfo;

        }
        public async Task<MechanismDto> CreateNewMechanismAsync(MechanismDto NewMechanismInfo)
        {
            var _mechanism = _mapper.Map<Mechanism>(NewMechanismInfo);

            var mechanismId = _repository.mechanism.FindAll().Max((m => m.Id));

            _repository.mechanism.Create(_mechanism);

            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");

            var createdmechanism = _mapper.Map<MechanismDto>(_mechanism);

            return createdmechanism;

        }
        public async Task UpdateMechanismAsync(int id, MechanismDto UpdatedMechanismInfo)
        {
            var _mechanism = await _repository.mechanism.GetMechanismByID(id);
            if (_mechanism == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _mapper.Map(UpdatedMechanismInfo, _mechanism);
            _mechanism.Id = id;
            _repository.mechanism.Update(_mechanism);
            _logger.LogInfo($"updated leadInfo for lead {id} in database.");


            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");
        }

        public async Task DeleteMechanismAsync(int id)
        {
            var _mechanism = await _repository.mechanism.GetMechanismByID(id);
            if (_mechanism == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _logger.LogInfo($"Getting Related logs in database.");

           // _repository.mechanism.Delete(_mechanism);
            _logger.LogInfo($"Deleted the lead {id} from database");

            await _repository.Save();
            _logger.LogInfo($"Commited all transactions in database.");
        }


    }
}
