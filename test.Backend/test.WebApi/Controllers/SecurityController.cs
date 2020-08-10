using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using test.Common.Dtos.User;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        [HttpPost]
        [Route("api/v{version:apiVersion}/security/")]
        [SwaggerOperation("Generate token")]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult> GetToken([FromBody] UserDto user)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return await new JsonResult("");
            });
        }

    }
}
