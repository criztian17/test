using System.Collections.Generic;
using System.Linq;
using test.Common.Dtos.Client;
using test.Common.Dtos.Policy;
using test.Repository.Entities;
using test.Utilities.Common;

namespace test.BusinessLogic.Mappers
{
    /// <summary>
    /// Class to Mapper the policy classes
    /// </summary>
    public static class PolicyMapperExtension
    {
        #region From PolicyDto To PolicyEntity
        /// <summary>
        /// Becomes a PolicyDto object to PolicyEntity object
        /// </summary>
        /// <typeparam name="TR">PolicyEntity object</typeparam>
        /// <param name="origin">PolicyDto object</param>
        /// <param name="result">PolicyEntity object</param>
        /// <param name="IncludeRelations">bool</param>
        /// <returns>PolicyEntity object</returns>
        public static TR ToEntityMapper<TR>(this PolicyDto origin, bool IncludeRelations = true)
        where TR : PolicyEntity, new()
        {
            return origin.ToEntityMapper(new TR(), IncludeRelations);
        }

        /// <summary>
        /// Becomes a PolicyEntity object to PolicyDto object
        /// </summary>
        /// <typeparam name="TR">PolicyDto object</typeparam>
        /// <param name="origin">PolicyEntity object</param>
        /// <param name="result">PolicyDto object</param>
        /// <param name="IncludeRelations">bool</param>
        public static TR ToEntityMapper<TR>(this PolicyDto origin, TR result, bool IncludeRelations = true)
        where TR : PolicyEntity, new()
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

                if (IncludeRelations)
                {
                    result.Client = origin.Client.ToEntityMapper<ClientEntity>();

                    result.PolicyDetails = origin.PolicyDetails.ToList().ToEntityListMapper<PolicyDetailEntity>();
                }
                else
                {
                    result.Client = new ClientEntity
                    {
                        Id = origin.Client.Id
                    };

                    result.PolicyDetails = new List<PolicyDetailEntity>();
                }

                result.Description = origin.Description;
                result.Id = origin.Id;
                result.Period = origin.Period;
                result.Price = origin.Price;
                result.RiskType = origin.RiskType;
                result.StartDate = origin.StartDate;
                result.State = origin.State;
            }

            return result;
        }

        /// <summary>
        /// Becomes a List of PolicyDto to list of entities
        /// </summary>
        /// <typeparam name="TR">entities</typeparam>
        /// <param name="origin">List of PolicyDto</param>
        /// <param name="IncludeRelations">bool</param>
        /// <returns></returns>
        public static List<TR> ToEntityListMapper<TR>(this List<PolicyDto> origin, bool IncludeRelations = true)
        where TR : PolicyEntity, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToEntityMapper(new TR(), IncludeRelations); });
        }
        #endregion

        #region From PolicyEntity To PolicyDto
        /// <summary>
        /// Becomes a PolicyEntity object to PolicyDto object
        /// </summary>
        /// <typeparam name="TR">PolicyDto object</typeparam>
        /// <param name="origin">PolicyEntity object</param>
        /// <param name="result">PolicyDto object</param>
        /// <param name="IncludeRelations">bool</param>
        /// <returns>PolicyDto object</returns>
        public static TR ToDtoMapper<TR>(this PolicyEntity origin, bool IncludeRelations = true)
        where TR : PolicyDto, new()
        {
            return origin.ToDtoMapper(new TR(), IncludeRelations);
        }

        /// <summary>
        /// Becomes a PolicyEntity object to PolicyDto object
        /// </summary>
        /// <typeparam name="TR">PolicyDto object</typeparam>
        /// <param name="origin">PolicyEntity object</param>
        /// <param name="result">PolicyDto object</param>
        /// <param name="IncludeRelations">bool</param>
        public static TR ToDtoMapper<TR>(this PolicyEntity origin, TR result, bool IncludeRelations = true)
        where TR : PolicyDto, new()
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

                if (IncludeRelations)
                {
                    result.Client = origin.Client.ToDtoMapper<ClientDto>();
                    result.PolicyDetails = origin.PolicyDetails.ToList().ToDtoListMapper<PolicyDetailDto>();
                }

                result.Description = origin.Description;
                result.Id = origin.Id;
                result.Period = origin.Period;
                result.Price = origin.Price;
                result.RiskType = origin.RiskType;
                result.StartDate = origin.StartDate;
                result.State = origin.State;
            }

            return result;
        }

        /// <summary>
        /// Becomes a List of entities to list of PolicyDto
        /// </summary>
        /// <typeparam name="TR">PolicyDto</typeparam>
        /// <param name="origin">List of Entities</param>
        /// <param name="IncludeRelations"></param>
        /// <returns></returns>
        public static List<TR> ToDtoListMapper<TR>(this List<PolicyEntity> origin, bool IncludeRelations = true)
        where TR : PolicyDto, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToDtoMapper(new TR(), IncludeRelations); });
        }

        #endregion
    }
}
