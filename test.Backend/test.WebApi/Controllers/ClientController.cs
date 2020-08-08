using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.Client;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
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

        [Route("api/v{version:apiVersion}/client/")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/v{version:apiVersion}/client/{id}")]
        public string GetClientById(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost]
        [Route("api/v{version:apiVersion}/client/")]
        [SwaggerOperation("Create new client")]
        [SwaggerResponse(400, type: typeof(List<RuleError>))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult> CreateClient([FromBody] ClientDto client)
        {
            return await ExecutionWrapperAPIExtension.ExecuteWrapperAPIAsync<ClientController>(this.HttpContext, async () =>
            {
                await _clientBL.CreateClientAsync(client);
                return Ok();
            });
        }

        //// PUT: api/Client/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //} 
        #endregion
    }
}
