using System.Linq;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    /// <summary>
    /// Coverage Repository Class
    /// </summary>
    public class CoverageRepository : GenericRepository<CoverageEntity>, ICoverageRepository
    {
        #region Attibutes
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public CoverageRepository(DataContext context):base(context)
        {
            this._context = context;
        }
        #endregion

        #region Public Methods
        public IQueryable<CoverageEntity> GetCoveragetByDescription(string description)
        {
            return _context.Coverages.Where(x => x.Description == description);
        }
        #endregion
    }
}
