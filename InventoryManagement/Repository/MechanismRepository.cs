using InventoryManagement.Data;
using InventoryManagement.Data.Models;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class MechanismRepository : RepositoryBase<Mechanism>, IMechanismRepository
    {
        public MechanismRepository(IMDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Mechanism>> GetAllMechanism()
        {

            return await FindAll()
                 .ToListAsync();
        }

        public async Task<Mechanism> GetMechanismByID(int id)
        {
            var mechanism = await FindByCondition(Mechanism => Mechanism.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (mechanism == null)
            {
                throw new NotFoundException($"No such contact exists in our database with id {id}");
            }
            return mechanism;
        }
    }
}
