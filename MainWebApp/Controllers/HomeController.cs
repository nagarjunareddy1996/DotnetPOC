using MainWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MainWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfigurationRoot ConfigRoot;

        public HomeController(ILogger<HomeController> logger, IConfiguration configRoot)
        {
            _logger = logger;
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var isSuccess = true;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(ConfigRoot["ServiceUrls:ServiceOneUrl"]))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (apiResponse == string.Empty)
                            throw new Exception("Error in Service One");
                    }
                }

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(ConfigRoot["ServiceUrls:ServiceTwoUrl"]))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (apiResponse == string.Empty)
                            throw new Exception("Error in Service Two");
                    }
                }

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(ConfigRoot["ServiceUrls:CallDBUrl"]))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (apiResponse == string.Empty)
                            throw new Exception("Error in Service Two on DB Call");
                    }
                }
            }
            catch(Exception ex)
            {
                isSuccess = false;
            }

            ViewData["Message"] = isSuccess;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
