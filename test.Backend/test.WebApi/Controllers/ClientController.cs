using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace test.WebApi.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        // GET: api/Client
        [HttpGet]
        [Route("user/status")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
