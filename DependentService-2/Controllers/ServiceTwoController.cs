using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependentService_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTwoController : ControllerBase
    {
        private IConfigurationRoot ConfigRoot;

        public ServiceTwoController(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        // GET: api/<ServiceTwoController>
        [HttpGet]
        public string Get()
        {
            return "This is message from Dependent Service 2";
        }

        // GET api/<ServiceTwoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "ServiceTwo-value";
        }

        // POST api/<ServiceTwoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceTwoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceTwoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
