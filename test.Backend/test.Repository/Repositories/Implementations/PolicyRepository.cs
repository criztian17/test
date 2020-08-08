using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    public class PolicyRepository : GenericRepository<PolicyEntity>, IPolicyRepository
    {
        #region Attibutes
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public PolicyRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
        #endregion
    }
}
