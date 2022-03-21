using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependentService_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOneController : ControllerBase
    {
        // GET: api/<ServiceOneController>
        [HttpGet]
        public string Get()
        {
            return "This is message from Dependent Service 1";
        }

        // GET api/<ServiceOneController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "ServiceOne-value";
        }

        // POST api/<ServiceOneController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceOneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceOneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
