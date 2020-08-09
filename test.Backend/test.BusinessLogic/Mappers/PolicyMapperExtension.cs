using System.Collections.Generic;
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
        #region FromDtoToEntity

        #endregion

        #region FromEntityToDto
        /// <summary>
        /// Becomes a ClientEntity object to ClientDto object
        /// </summary>
        /// <typeparam name="TR">ClientDto object</typeparam>
        /// <param name="origin">ClientEntity object</param>
        /// <param name="result">ClientDto object</param>
        /// <param name="IncludeRelations">bool</param>
        /// <returns>ClientDto object</returns>
        public static TR ToDtoMapper<TR>(this PolicyEntity origin , bool IncludeRelations = true)
        where TR : PolicyDto, new()
        {
            return origin.ToDtoMapper(new TR() , IncludeRelations);
        }

        /// <summary>
        /// Becomes a ClientEntity object to ClientDto object
        /// </summary>
        /// <typeparam name="TR">ClientDto object</typeparam>
        /// <param name="origin">ClientEntity object</param>
        /// <param name="result">ClientDto object</param>
        /// <param name="IncludeRelations">bool</param>
        public static TR ToDtoMapper<TR>(this PolicyEntity origin, TR result , bool IncludeRelations = true)
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
                    //TODO: pending details
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
        public static List<TR> ToDtoListMapper<TR>(this List<PolicyEntity> origin , bool IncludeRelations = true)
        where TR : PolicyDto, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToDtoMapper(new TR() , IncludeRelations); });
        }

        #endregion
    }
}
