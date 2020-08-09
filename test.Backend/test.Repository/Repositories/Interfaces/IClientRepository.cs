using System.Linq;
using test.Repository.Entities;

namespace test.Repository.Repositories.Interfaces
{
    public interface IClientRepository : IGenericRepository<ClientEntity>
    {
        IQueryable<ClientEntity> GetClientByIdentification(string identification);
    }
}
