using System.Linq;
using test.Common.Dtos.User;
using test.Repository.Entities;

namespace test.Repository.Repositories.Interfaces
{
    /// <summary>
    /// User Respository Interface
    /// </summary>
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        /// <summary>
        /// Get a user by UserName
        /// </summary>
        /// <param name="user">UserDto object</param>
        /// <returns>IQueryable</returns>
        IQueryable<UserEntity> GetUserUserByUserName(UserDto user);
    }
}
