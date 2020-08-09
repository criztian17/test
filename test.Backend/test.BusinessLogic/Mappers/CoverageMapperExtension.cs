using System;
using System.Collections.Generic;
using System.Text;
using test.Common.Dtos.Coverage;
using test.Repository.Entities;
using test.Utilities.Common;

namespace test.BusinessLogic.Mappers
{
    /// <summary>
    /// Class to Mapper the coverage classes
    /// </summary>
    public static class CoverageMapperExtension
    {
        #region From CoveragetDto To CoverageEntity
        /// <summary>
        /// Becomes a CoverageDto object to CoverageEntity object
        /// </summary>
        /// <typeparam name="TR">CoverageEntity object</typeparam>
        /// <param name="origin">CoverageDto object</param>
        /// <returns>CoverageEntity object</returns>
        public static TR ToEntityMapper<TR>(this CoverageDto origin)
        where TR : CoverageEntity, new()
        {
            return origin.ToEntityMapper(new TR());
        }

        /// <summary>
        /// Becomes a CoverageDto object to CoverageEntity object
        /// </summary>
        /// <typeparam name="TR">CoverageEntity object</typeparam>
        /// <param name="origin">CoverageDto object</param>
        /// <param name="result">CoverageEntity object</param>
        /// <returns>CoverageEntity object</returns>
        public static TR ToEntityMapper<TR>(this CoverageDto origin, TR result)
        where TR : CoverageEntity, new()
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
                result.Description = origin.Description;
            }

            return result;
        }
        #endregion

        #region From CoverageEntity To CoverageDto
        /// <summary>
        /// Becomes a CoverageEntity object to CoverageDto object
        /// </summary>
        /// <typeparam name="TR">CoverageDto object</typeparam>
        /// <param name="origin">CoverageEntity object</param>
        /// <returns>CoverageDto object</returns>
        public static TR ToDtoMapper<TR>(this CoverageEntity origin)
        where TR : CoverageDto, new()
        {
            return origin.ToDtoMapper(new TR());
        }

        /// <summary>
        /// Becomes a CoverageEntity object to CoverageDto object
        /// </summary>
        /// <typeparam name="TR">CoverageDto object</typeparam>
        /// <param name="origin">CoverageEntity object</param>
        /// <param name="result">CoverageDto object</param>
        /// <returns>CoverageDto object</returns>
        public static TR ToDtoMapper<TR>(this CoverageEntity origin, TR result)
        where TR : CoverageDto, new()
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
                result.Description = origin.Description;
            }

            return result;
        }

        /// <summary>
        /// Becomes a List of entities to list of CoverageDto
        /// </summary>
        /// <typeparam name="TR">CoverageDto</typeparam>
        /// <param name="origin">List of Entities</param>
        /// <param name="IncludeRelations"></param>
        /// <returns></returns>
        public static List<TR> ToDtoListMapper<TR>(this List<CoverageEntity> origin)
        where TR : CoverageDto, new()
        {
            return CommonUtilities.ListCast(origin, (originItem) => { return originItem.ToDtoMapper(new TR()); });
        }
#endregion
    }
}
