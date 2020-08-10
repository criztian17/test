using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    public class PolicyDetailRepository : GenericRepository<PolicyDetailEntity>, IPolicyDetailRepository
    {

        #region Attibutes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PolicyDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion
    }
}
