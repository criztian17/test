using System.Collections.Generic;
using test.Common.Dtos.Coverage;
using test.Common.Dtos.Policy;
using test.Repository.Entities;
using test.Utilities.Common;

namespace test.BusinessLogic.Mappers
{
    /// <summary>
    /// Class to Mapper the coverage classes
    /// </summary>
    public static class PolicyDetailMapperExtension
    {
        #region From PolicyDetailDto To PolicyDetailEntity
        /// <summary>
        /// Becomes a PolicyDetailDto object to PolicyDetailEntity object
        /// </summary>
        /// <typeparam name="TR">PolicyDetailEntity object</typeparam>
        /// <param name="origin">PolicyDetailDto object</param>
        /// <returns>PolicyDetailEntity object</returns>
        public static TR ToEntityMapper<TR>(this PolicyDetailDto origin)
        where TR : PolicyDetailEntity, new()
        {
            return origin.ToEntityMapper(new TR());
        }

        /// <summary>
        /// Becomes a PolicyDetailDto object to PolicyDetailEntity object
        /// </summary>
        /// <typeparam name="TR">PolicyDetailEntity object</typeparam>
        /// <param name="origin">PolicyDetailDto object</param>
        /// <param name="result">PolicyDetailEntity object</param>
        /// <returns>PolicyDetailEntity object</returns>
        public static TR ToEntityMapper<TR>(this PolicyDetailDto origin, TR result)
        where TR : PolicyDetailEntity, new()
        {
            if (origin == null)
            {
                result = default;
            }
            else
            {
                if (result == null)
                {
                    result = new TR();
                }

                result.Id = origin.Id;
                result.Coverage = origin.Coverage.ToEntityMapper<CoverageEntity>();
                result.CoveragePercentage = origin.CoveragePercentage;

                //Not require the Policy
                result.Policy = new PolicyEntity();
                
            }

            return result;
        }

        /// <summary>
        /// Becomes a List of PolicyDetailDto  to list of PolicyDetailEntity
        /// </summary>
        /// <typeparam name="TR">PolicyDetailEntity</typeparam>
        /// <param name="origin">List of PolicyDetailDto</param>
        /// <returns></returns>
        public static List<TR> ToEntityListMapper<TR>(this List<PolicyDetailDto> origin)
        where TR : PolicyDetailEntity, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToEntityMapper(new TR()); });
        }

        #endregion

        #region From CoverageEntity To CoverageDto
        /// <summary>
        /// Becomes a PolicyDetailEntity object to PolicyDetailDto object
        /// </summary>
        /// <typeparam name="TR">PolicyDetailDto object</typeparam>
        /// <param name="origin">PolicyDetailEntity object</param>
        /// <returns>PolicyDetailDto object</returns>
        public static TR ToDtoMapper<TR>(this PolicyDetailEntity origin)
        where TR : PolicyDetailDto, new()
        {
            return origin.ToDtoMapper(new TR());
        }

        /// <summary>
        /// Becomes a PolicyDetailEntity object to PolicyDetailDto object
        /// </summary>
        /// <typeparam name="TR">PolicyDetailDto object</typeparam>
        /// <param name="origin">PolicyDetailEntity object</param>
        /// <param name="result">PolicyDetailDto object</param>
        /// <returns>PolicyDetailDto object</returns>
        public static TR ToDtoMapper<TR>(this PolicyDetailEntity origin, TR result)
        where TR : PolicyDetailDto, new()
        {
            if (origin == null)
            {
                result = default(TR);
            }
            else
            {
                if (result == null)
                {
                    result = new TR();
                }

                result.Id = origin.Id;
                result.CoveragePercentage = origin.CoveragePercentage;
                result.Coverage = origin.Coverage.ToDtoMapper<CoverageDto>();
            }

            return result;
        }

        /// <summary>
        /// Becomes a List of PolicyDetailEntity to list of PolicyDetailDto
        /// </summary>
        /// <typeparam name="TR">PolicyDetailDto</typeparam>
        /// <param name="origin">List of PolicyDetailEntity</param>
        /// <param name="IncludeRelations"></param>
        public static List<TR> ToDtoListMapper<TR>(this List<PolicyDetailEntity> origin)
        where TR : PolicyDetailDto, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToDtoMapper(new TR()); });
        }
        #endregion
    }
}
