using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.Policy;

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
        //[SwaggerOperation("Get resource by Email and PropertyId")]
        //[SwaggerResponse(200, type: typeof(List<ResourceModel>))]
        //[SwaggerResponse(400, type: typeof(List<RuleError>))]
        //[SwaggerResponse(500, Description = "Internal Server Error", type: typeof(ApiError))]
        public IActionResult GetPolicies()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        //[HttpGet]
        //[Route("api/v{version:apiVersion}/policy/")]
        //public string GetPoicyById(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        [Route("api/v{version:apiVersion}/policy/")]
        //[SwaggerOperation("Create new policy")]
        [SwaggerResponse(200, type: typeof(PolicyDto))]
        //[SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<PolicyDto>> CreatePolicy([FromBody] PolicyDto policy)
        {
            var result = await _policyBL.CreatePolicy(policy);
            return Ok(policy);
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
