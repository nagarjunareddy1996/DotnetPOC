using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainServiceController : ControllerBase
    {
        private IConfigurationRoot ConfigRoot;

        public MainServiceController(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        // GET: api/<MainServiceController>
        [HttpGet]
        [Route("CallServiceOne")]
        public async Task<string> CallServiceOneAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ConfigRoot["ServiceUrls:ServiceOneUrl"]))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        [HttpGet]
        [ActionName("CallServiceTwo")]
        public async Task<string> CallServiceTwoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ConfigRoot["ServiceUrls:ServiceTwoUrl"]))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        [HttpGet]
        [ActionName("CallServiceTwoDb")]
        public async Task<string> CallServiceTwoDbAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ConfigRoot["ServiceUrls:CallDBUrl"]))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        // GET api/<MainServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MainServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MainServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MainServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
