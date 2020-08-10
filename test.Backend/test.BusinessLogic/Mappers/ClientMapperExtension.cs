using System.Collections.Generic;
using System.Linq;
using test.Common.Dtos.Client;
using test.Common.Dtos.Policy;
using test.Repository.Entities;
using test.Utilities.Common;

namespace test.BusinessLogic.Mappers
{
    /// <summary>
    /// Class to Mapper the client classes
    /// </summary>
    public static class ClientMapperExtension
    {
        #region From ClientDto To ClientEntity
        /// <summary>
        /// Becomes a ClientDto object to ClientEntity object
        /// </summary>
        /// <typeparam name="TR">ClientEntity object</typeparam>
        /// <param name="origin">ClientDto object</param>
        /// <returns>ClientEntity object</returns>
        public static TR ToEntityMapper<TR>(this ClientDto origin)
        where TR : ClientEntity, new()
        {
            return origin.ToEntityMapper(new TR());
        }

        /// <summary>
        /// Becomes a ClientDto object to ClientEntity object
        /// </summary>
        /// <typeparam name="TR">ClientEntity object</typeparam>
        /// <param name="origin">ClientDto object</param>
        /// <param name="result">ClientEntity object</param>
        /// <returns>ClientEntity object</returns>
        public static TR ToEntityMapper<TR>(this ClientDto origin, TR result)
        where TR : ClientEntity, new()
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
                result.Identification = origin.Identification;
                result.Name = origin.Name;
            }

            return result;
        }
        #endregion

        #region From ClientEntity To ClientDto
        /// <summary>
        /// Becomes a ClientEntity object to ClientDto object
        /// </summary>
        /// <typeparam name="TR">ClientDto object</typeparam>
        /// <param name="origin">ClientEntity object</param>
        /// <returns>ClientDto object</returns>
        public static TR ToDtoMapper<TR>(this ClientEntity origin)
        where TR : ClientDto, new()
        {
            return origin.ToDtoMapper(new TR());
        }

        /// <summary>
        /// Becomes a ClientEntity object to ClientDto object
        /// </summary>
        /// <typeparam name="TR">ClientDto object</typeparam>
        /// <param name="origin">ClientEntity object</param>
        /// <param name="result">ClientDto object</param>
        /// <returns>ClientDto object</returns>
        public static TR ToDtoMapper<TR>(this ClientEntity origin, TR result)
        where TR : ClientDto, new()
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
                result.Identification = origin.Identification;
                result.Name = origin.Name;
            }

            return result;
        }

        /// <summary>
        /// Becomes a List of entities to list of ClientDto
        /// </summary>
        /// <typeparam name="TR">ClientDto</typeparam>
        /// <param name="origin">List of Entities</param>
        /// <param name="IncludeRelations"></param>
        /// <returns></returns>
        public static List<TR> ToDtoListMapper<TR>(this List<ClientEntity> origin)
        where TR : ClientDto, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToDtoMapper(new TR()); });
        }
        #endregion
    }
}
