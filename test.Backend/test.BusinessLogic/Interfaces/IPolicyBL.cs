using System.Collections.Generic;
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

        /// <summary>
        /// Get a policy by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PolicyDto object</returns>
        Task<PolicyDto> GetPolicyByIdAsync(int id);


        /// <summary>
        /// Validate if the policy exists into the database
        /// </summary>
        /// <param name="id">Polocy Id</param>
        /// <returns>bool</returns>
        Task<bool> ExistAsync(int id);

        /// <summary>
        /// Get a collection of policues
        /// </summary>
        /// <returns>ICollection</returns>
        Task<ICollection<PolicyDto>> GetAllActiveAsync();

        /// <summary>
        /// Updates a policy
        /// </summary>
        /// <param name="client">PolicyDto object</param>
        /// <param name="id">Policy id</param>
        /// <returns>bool</returns>
        Task<bool> UpdatePolicyAsync(int id, PolicyDto coverage);

        /// <summary>
        /// Cancels a policy 
        /// </summary>
        /// <param name="id">Policy Id</param>
        /// <returns>bool</returns>
        Task<bool> DeletePolicytAsync(int id);

    }
}
