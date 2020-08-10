using System.Linq;
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
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ClientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        public IQueryable<ClientEntity> GetClientByIdentification(string identification)
        {
            return _unitOfWork.DataContext.Clients.Where(x => x.Identification == identification);
        }
        #endregion
    }
}
