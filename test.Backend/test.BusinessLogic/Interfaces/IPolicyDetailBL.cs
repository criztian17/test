using System.Collections.Generic;
using System.Threading.Tasks;
using test.Common.Dtos.Policy;

namespace test.BusinessLogic.Interfaces
{
    /// <summary>
    /// PolicyDetailBL Interface
    /// </summary>
    public interface IPolicyDetailBL 
    {

        /// <summary>
        /// Creates new Policy Detail
        /// </summary>
        /// <param name="policyDetail">PolicyDetailDto object</param>
        /// <returns>bool</returns>
        Task<bool> CreatePolicyDetailtAsync(PolicyDetailDto policyDetail);

        /// <summary>
        /// Gets a policyDetail by id
        /// </summary>
        /// <param name="id">PolicyDetail id</param>
        /// <returns>PolicyDetailDto object</returns>
        Task<PolicyDetailDto> GetPolicyDetailByIdAsync(int id);


        /// <summary>
        /// Validates if the policyDetail exists into the database
        /// </summary>
        /// <param name="id">PolicyDetail Id</param>
        /// <returns>bool</returns>
        Task<bool> ExistAsync(int id);

        /// <summary>
        /// Get a collection of PolicyDetails
        /// </summary>
        /// <returns>Icollection</returns>
        Task<ICollection<PolicyDetailDto>> GetAllAsync();

        /// <summary>
        /// Updates a policyDetail
        /// </summary>
        /// <param name="policyDetail">PolicyDetailDto object</param>
        /// <param name="id">policyDetail id</param>
        /// <returns>bool</returns>
        Task<bool> UpdatePolicyDetailAsync(int id, PolicyDetailDto policyDetail);

        /// <summary>
        /// Deletes a policyDetail 
        /// </summary>
        /// <param name="id">PolicyDetail Id</param>
        /// <returns>bool</returns>
        Task<bool> DeletePolicyAsync(int id);

        /// <summary>
        /// Validates the Percentage Business Rule
        /// </summary>
        /// <param name="policyDetail"></param>
        void ValidatePercentageBusinessRule(PolicyDetailDto policyDetail);

    }
}
