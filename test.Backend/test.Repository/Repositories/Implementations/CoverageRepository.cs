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
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CoverageRepository(IUnitOfWork unitOfWork) :base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        public IQueryable<CoverageEntity> GetCoveragetByDescription(string description)
        {
            return _unitOfWork.DataContext.Coverages.Where(x => x.Description == description);
        }
        #endregion
    }
}
