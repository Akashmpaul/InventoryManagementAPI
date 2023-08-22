using InventoryManagement.Data;
using InventoryManagement.Data.Models;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class NozzleFlowRepository : RepositoryBase<NozzleFlow>, INozzleFlowRepository
    {
        public NozzleFlowRepository(IMDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<NozzleFlow>> GetAllNozzleFlow()
        {

            return await FindAll()
                .ToListAsync();
        }

        public async Task<NozzleFlow> GetNozzleFlowByID(int id)
        {
            var nozzleflow = await FindByCondition(NozzleFlow => NozzleFlow.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (nozzleflow == null)
            {
                throw new NotFoundException($"No such contact exists in our database with id {id}");
            }
            return nozzleflow;
        }
    }
}
