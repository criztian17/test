using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.User;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        #region Attributes
        private readonly IUserBL _userBL;
        #endregion

        #region Constructor
        public SecurityController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        #endregion

        #region Actions
        [HttpPost]
        [Route("api/v{version:apiVersion}/security/")]
        [SwaggerOperation("Generate token")]
        [SwaggerResponse(200, type: typeof(TokenDto))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<TokenDto>> GetToken([FromBody] UserDto user)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<CoverageController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _userBL.GenerateTokenAsync(user));
            });
        } 
        #endregion

    }
}
