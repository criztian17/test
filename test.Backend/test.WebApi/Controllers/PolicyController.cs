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
        [HttpGet]
        [Route("api/v{version:apiVersion}/policy/")]
        public IActionResult GetPolicies()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpGet]
        [Route("api/v{version:apiVersion}/policy/{id}")]
        public string GetPolicyById(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("api/v{version:apiVersion}/policy/")]
        [SwaggerOperation("Create new policy")]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult> CreatePolicy([FromBody] PolicyDto policy)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<PolicyController>(this.HttpContext, async () =>
            {
                await _policyBL.CreatePolicyAsync(policy);
                return Ok();
            });
        }

        [HttpPut]
        [Route("api/v{version:apiVersion}/policy/")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        [Route("api/v{version:apiVersion}/policy/")]
        public void Delete(int id)
        {
        } 
        #endregion
    }
}
