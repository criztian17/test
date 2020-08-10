using System.Linq;
using test.Common.Dtos.User;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    /// <summary>
    /// User Repository Class
    /// </summary>
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        #region Attibutes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion


        #region Public Methods
        public IQueryable<UserEntity> GetUserUserByUserName(UserDto user)
        {
           return _unitOfWork.DataContext.Users.Where(x => x.UserLogin == user.UserLogin);
        } 
        #endregion
    }
}
