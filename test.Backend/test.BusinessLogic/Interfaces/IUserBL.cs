using System.Threading.Tasks;
using test.Common.Dtos.User;

namespace test.BusinessLogic.Interfaces
{
    /// <summary>
    /// User Business Logic Interface
    /// </summary>
    public interface IUserBL
    {
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="user">UserDto object</param>
        /// <returns>bool</returns>
        Task<bool> GenerateTokenAsync(UserDto user);
    }
}
