using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.Coverage;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class CoverageController : ControllerBase
    {
        #region Attributes
        private readonly ICoverageBL _coverageBL;
        #endregion

        #region Constructor
        public CoverageController(ICoverageBL coverageBL)
        {
            _coverageBL = coverageBL;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get a list of CoverageDto
        /// </summary>
        /// <returns>ICollection of CoverageDto</returns>
        [Route("api/v{version:apiVersion}/coverage/")]
        [HttpGet]
        [SwaggerOperation("Get list of Coverages")]
        [SwaggerResponse(200, type: typeof(ICollection<CoverageDto>))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<CoverageDto>>> Get()
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _coverageBL.GetAllAsync());
            });
        }

        /// <summary>
        /// Get a coverage by Id
        /// </summary>
        /// <param name="id">coverage id</param>
        /// <returns>CoverageDto</returns>
        [HttpGet]
        [Route("api/v{version:apiVersion}/coverage/{id}")]
        [SwaggerOperation("Get a coverage by Id")]
        [SwaggerResponse(200, type: typeof(CoverageDto))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<CoverageDto>> GetCoverageById(int id)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _coverageBL.GetCoverageByIdAsync(id));
            });
        }

        /// <summary>
        /// Get a coverage by description
        /// </summary>
        /// <param name="description">coverage description</param>
        /// <returns>CoverageDto<returns>
        [HttpGet]
        [Route("api/v{version:apiVersion}/coverage/description/{description}")]
        [SwaggerOperation("Get a coverage by description")]
        [SwaggerResponse(200, type: typeof(CoverageDto))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<CoverageDto>> GetCoverageByDescription(string description)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _coverageBL.GetCoverageByDescriptionAsync(description));
            });
        }

        /// <summary>
        /// Creates new coverage
        /// </summary>
        /// <param name="coverage">CoverageDto object</param>
        /// <returns>bool</returns>
        [HttpPost]
        [Route("api/v{version:apiVersion}/coverage/")]
        [SwaggerOperation("Create new coverage")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> CreateCoverage([FromBody] CoverageDto coverage)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _coverageBL.CreateCoverageAsync(coverage));
            });
        }

        /// <summary>
        /// Updates a coverage
        /// </summary>
        /// <param name="id">Coverage id</param>
        /// <param name="coverage">CoverageDto object</param>
        /// <returns>bool</returns>
        [HttpPut]
        [Route("api/v{version:apiVersion}/coverage/")]
        [SwaggerOperation("Update coverage")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> UpdateCoverage(int id, [FromBody] CoverageDto coverage)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _coverageBL.UpdateCoverageAsync(id, coverage));
            });
        }

        /// <summary>
        /// Deletes a coverage
        /// </summary>
        /// <param name="id">Coverage id</param>
        /// <returns>bool</returns>
        [HttpDelete]
        [Route("api/v{version:apiVersion}/coverage/")]
        [SwaggerOperation("Delete coverage")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> DeleteCoverage(int id)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _coverageBL.DeleteCoveragetAsync(id));
            });
        }
        #endregion
    }
}
