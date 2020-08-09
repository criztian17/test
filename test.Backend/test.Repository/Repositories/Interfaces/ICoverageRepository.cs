using System.Linq;
using test.Repository.Entities;

namespace test.Repository.Repositories.Interfaces
{
    public interface ICoverageRepository : IGenericRepository<CoverageEntity>
    {
        /// <summary>
        /// Gets an IQueryable of Coverage
        /// </summary>
        /// <param name="description">Coverage description</param>
        /// <returns>IQueryable</returns>
        IQueryable<CoverageEntity> GetCoveragetByDescription(string description);
    }
}
