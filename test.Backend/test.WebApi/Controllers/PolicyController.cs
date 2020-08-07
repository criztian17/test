using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test.Common.Dtos.Policy;

namespace test.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        // GET: api/Policy
        [HttpGet]
        [Route("api/v{version:apiVersion}/policy/")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Policy/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Policy
        [HttpPost]
        [Route("api/v{version:apiVersion}/policy/")]
        public void Post([FromBody] PolicyDto policy)
        {
        }

        //// PUT: api/Policy/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
