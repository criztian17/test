using System.Collections.Generic;
using System.Threading.Tasks;
using test.Common.Dtos.Coverage;

namespace test.BusinessLogic.Interfaces
{
    /// <summary>
    /// CoverageBL Interface
    /// </summary>
    public interface ICoverageBL
    {
        /// <summary>
        /// Creates new Coverage
        /// </summary>
        /// <param name="coverage">CoverageDto object</param>
        /// <returns></returns>
        Task<bool> CreateCoverageAsync(CoverageDto coverage);

        /// <summary>
        /// Gets a client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CoverageDto object</returns>
        Task<CoverageDto> GetCoverageByIdAsync(int id);


        /// <summary>
        /// Validates if the coverage exists into the database
        /// </summary>
        /// <param name="id">Coverage Id</param>
        /// <returns>bool</returns>
        Task<bool> ExistAsync(int id);

        /// <summary>
        /// Get a collection of coverages
        /// </summary>
        /// <returns>ICollection</returns>
        Task<ICollection<CoverageDto>> GetAllAsync();

        /// <summary>
        /// Updates a coverage
        /// </summary>
        /// <param name="client">CoverageDto object</param>
        /// <param name="id">Coverage id</param>
        /// <returns>bool</returns>
        Task<bool> UpdateCoverageAsync(int id, CoverageDto coverage);

        /// <summary>
        /// Deletes a coverage 
        /// </summary>
        /// <param name="id">Coverage Id</param>
        /// <returns>bool</returns>
        Task<bool> DeleteCoveragetAsync(int id);

        /// <summary>
        /// Get a coverage by description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<CoverageDto> GetCoverageByDescriptionAsync(string description, bool throwException = true);
    }
}
