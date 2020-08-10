using System.Linq;
using test.Repository.Entities;

namespace test.Repository.Repositories.Interfaces
{
    public interface IClientRepository : IGenericRepository<ClientEntity>
    {
        /// <summary>
        /// Get an IQueryable of ClientEntity
        /// </summary>
        /// <param name="identification">Client identification</param>
        /// <returns>IQueryable</returns>
        IQueryable<ClientEntity> GetClientByIdentification(string identification);
    }
}
