using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.Policy;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        #region Attributes
        private readonly IPolicyBL _policyBL;
        #endregion

        #region Constructor
        public PolicyController(IPolicyBL policyBL)
        {
            _policyBL = policyBL;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get a list of CoverageDto
        /// </summary>
        /// <returns>ICollection of CoverageDto</returns>
        [Route("api/v{version:apiVersion}/policy/")]
        [HttpGet]
        [SwaggerOperation("Get a list of Policies")]
        [SwaggerResponse(200, type: typeof(ICollection<PolicyDto>))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<PolicyDto>>> Get()
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _policyBL.GetAllWithRelationsAsync());
            });
        }

        [HttpGet]
        [Route("api/v{version:apiVersion}/policy/{id}")]
        [SwaggerOperation("Get a policy by Id")]
        [SwaggerResponse(200, type: typeof(PolicyDto))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<PolicyDto>> GetPolicyById(int id)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _policyBL.GetPolicyByIdAsync(id));
            });
        }

        [HttpPost]
        [Route("api/v{version:apiVersion}/policy/")]
        [SwaggerOperation("Create new policy")]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> CreatePolicy([FromBody] PolicyDto policy)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<PolicyController>(this.HttpContext, async () =>
            {
                return new JsonResult( await _policyBL.CreatePolicyAsync(policy));
            });
        }

        [HttpDelete]
        [Route("api/v{version:apiVersion}/policy/")]
        [SwaggerOperation("Mark a policy as canceled")]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> DeleteCoverage(int id)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _policyBL.DeletePolicytAsync(id));
            });
        }
        #endregion
    }
}
