using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    /// <summary>
    /// Client Repository Class
    /// </summary>
    public class ClientRepository : GenericRepository<ClientEntity>, IClientRepository
    {
        #region Attibutes
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public ClientRepository(DataContext context) : base(context)
        {
            this._context = context;
        } 
        #endregion
    }
}
