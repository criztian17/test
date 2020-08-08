using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    public class PolicyDetailRepository : GenericRepository<PolicyDetailEntity>, IPolicyDetailRepository
    {

        #region Attibutes
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public PolicyDetailRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
        #endregion
    }
}
