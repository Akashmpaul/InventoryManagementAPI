using AutoMapper;
using InventoryManagement.Data.Models;
using InventoryManagement.DTOs;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository.Contracts;

namespace InventoryManagement.Services
{
    public class NozzleFlowService : INozzleFlowService
    {
        private readonly IIMDbRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public NozzleFlowService(IIMDbRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NozzleFlowDto>> GetAllNozzleFlowAsync()
        {
            var _nozzle = await _repository.nozzle.GetAllNozzleFlow();
            _logger.LogInfo($"Returned all contacts from database.");
            var nozzleResult = _mapper.Map<IEnumerable<NozzleFlowDto>>(_nozzle);
            return nozzleResult;
        }
        public async Task<NozzleFlowDto> GetNozzleFlowByIDAsync(int id)
        {
            var _nozzle = await _repository.nozzle.GetNozzleFlowByID(id);

            if (_nozzle == null)
            {
                throw new NotFoundException($"Contacts with name: {id}, hasn't been found in db.");
            }
            _logger.LogInfo($"Returned Contact details with name: {id}");

            var nozzleInfo = _mapper.Map<NozzleFlowDto>(_nozzle);
            return nozzleInfo;

        }
        public async Task<NozzleFlowDto> CreateNewNozzleFlowAsync(NozzleFlowDto NewNozzleFlowInfo)
        {
            var _nozzle = _mapper.Map<NozzleFlow>(NewNozzleFlowInfo);

            var _nozzleId = _repository.nozzle.FindAll().Max((nf => nf.Id));

            _repository.nozzle.Create(_nozzle);

            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");

            var creatednozzle = _mapper.Map<NozzleFlowDto>(_nozzle);

            return creatednozzle;

        }
        public async Task UpdateNozzleFlowAsync(int id, NozzleFlowDto UpdatedNozzleFlowInfo)
        {
            var _nozzle = await _repository.nozzle.GetNozzleFlowByID(id);
            if (_nozzle == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _mapper.Map(UpdatedNozzleFlowInfo, _nozzle);
            _nozzle.Id = id;
            _repository.nozzle.Update(_nozzle);
            _logger.LogInfo($"updated leadInfo for lead {id} in database.");


            await _repository.Save();

            _logger.LogInfo($"Commited all transactions in database.");
        }

        public async Task DeleteNozzleFlowAsync(int id)
        {
            var _nozzle = await _repository.nozzle.GetNozzleFlowByID(id);
            if (_nozzle == null)
            {
                throw new NotFoundException($"Lead with id: {id} doesn't exist in the database.");
            }

            _logger.LogInfo($"Getting Related logs in database.");

            _repository.nozzle.Delete(_nozzle);
            _logger.LogInfo($"Deleted the lead {id} from database");

            await _repository.Save();
            _logger.LogInfo($"Commited all transactions in database.");
        }


    }
}
}
