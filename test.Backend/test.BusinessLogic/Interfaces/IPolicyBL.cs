using System.Threading.Tasks;
using test.Common.Dtos.Policy;

namespace test.BusinessLogic.Interfaces
{
    /// <summary>
    /// PolicyBL Interface
    /// </summary>
    public interface IPolicyBL
    {
        /// <summary>
        /// Create New Policy
        /// </summary>
        /// <param name="policy">PolicyDto object</param>
        /// <returns>PolicyDto Object</returns>
        Task<bool> CreatePolicyAsync(PolicyDto policy);
    }
}
