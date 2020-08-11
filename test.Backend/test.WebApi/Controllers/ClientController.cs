using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.Client;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.WebApi.Controllers
{
    
    [ApiVersion("1.0")]
    [ApiController ]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        #region Attributes
        private readonly IClientBL _clientBL;
        #endregion

        #region Constructor
        public ClientController(IClientBL clientBL)
        {
            _clientBL = clientBL;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get a list of ClientDto
        /// </summary>
        /// <returns>ICollection of ClientDto</returns>
        [Route("api/v{version:apiVersion}/client/")]
        [HttpGet]
        [SwaggerOperation("Get list of Clients")]
        [SwaggerResponse(401, Description = "Unauthorized")]
        [SwaggerResponse(200, type: typeof(ICollection<ClientDto>))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<ClientDto>>> Get()
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _clientBL.GetAllAsync());
            });
        }

        /// <summary>
        /// Get a client by Id
        /// </summary>
        /// <param name="id">client id</param>
        /// <returns>ClientDto</returns>
        [HttpGet]
        [Route("api/v{version:apiVersion}/client/{id}")]
        [SwaggerOperation("Get a client by Id")]
        [SwaggerResponse(200, type: typeof(ClientDto))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _clientBL.GetClientByIdAsync(id));
            });
        }

        /// <summary>
        /// Get a client by identification
        /// </summary>
        /// <param name="identification">Client Identification</param>
        /// <returns>ClientDto<returns>
        [HttpGet]
        [Route("api/v{version:apiVersion}/client/identification/{identification}")]
        [SwaggerOperation("Get a client by identification")]
        [SwaggerResponse(200, type: typeof(ClientDto))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ClientDto>> GetClientByIdentification(string identification)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _clientBL.GetClientByIdentificationAsync(identification));
            });
        }

        /// <summary>
        /// Creates a new client
        /// </summary>
        /// <param name="client">ClientDto object</param>
        /// <returns>bool</returns>
        [HttpPost]
        [Route("api/v{version:apiVersion}/client/")]
        [SwaggerOperation("Create new client")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> CreateClient([FromBody] ClientDto client)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _clientBL.CreateClientAsync(client));
            });
        }

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="client">ClientDto object</param>
        /// <returns>bool</returns>
        [HttpPut]
        [Route("api/v{version:apiVersion}/client/")]
        [SwaggerOperation("Update client")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> UpdateClient(int id, [FromBody] ClientDto client)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _clientBL.UpdateClientAsync(id,client));
            });
        }

        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>bool</returns>
        [HttpDelete]
        [Route("api/v{version:apiVersion}/client/")]
        [SwaggerOperation("Delete client")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> DeleteClient(int id)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                return new JsonResult(await _clientBL.DeleteClientAsync(id));
            });
        }
        #endregion
    }
}
