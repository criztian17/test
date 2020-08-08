using test.Common.Dtos.Client;
using test.Repository.Entities;

namespace test.BusinessLogic.Mappers
{
    /// <summary>
    /// Class to Mapper the client classes
    /// </summary>
    public static class ClientMapperExtension
    {
        #region FromClientDtoToEntity
        /// <summary>
        /// Becomes a ClientDto object to ClientEntity object
        /// </summary>
        /// <typeparam name="TR">ClientEntity object</typeparam>
        /// <param name="origin">ClientDto object</param>
        /// <returns>ClientEntity object</returns>
        public static TR ToEntity<TR>(this ClientDto origin)
        where TR : ClientEntity, new()
        {
            return origin.ToEntity(new TR());
        }

        /// <summary>
        /// Becomes a ClientDto object to ClientEntity object
        /// </summary>
        /// <typeparam name="TR">ClientEntity object</typeparam>
        /// <param name="origin">ClientDto object</param>
        /// <param name="result">ClientEntity object</param>
        /// <returns>ClientEntity object</returns>
        public static TR ToEntity<TR>(this ClientDto origin, TR result)
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
    }
}
