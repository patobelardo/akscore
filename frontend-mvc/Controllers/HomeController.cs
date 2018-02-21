using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using frontend_mvc.Models;
using Microsoft.Extensions.Options;
using RestSharp;
using Newtonsoft.Json;

namespace frontend_mvc.Controllers
{
    public class HomeController : Controller
    {
        string _webapiURL = "";
        public HomeController(IOptions<WebAPISettings> settings)
        {
            _webapiURL = settings.Value.URL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            EnvironmentBE apienv = new EnvironmentBE();
            try
            {
                var client = new RestClient($"{_webapiURL}/api/env");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                apienv =JsonConvert.DeserializeObject<EnvironmentBE>(response.Content);
            }
            catch(Exception ex)
            {
                apienv.MachineName = ex.Message.ToString();
            }
            if (apienv == null)
                apienv = new EnvironmentBE{ MachineName = "Not found"};
                
            var viewmodel = new EnvironmentViewModel { 
                EnvFrontEnd = new EnvironmentBE{
                    MachineName = Environment.MachineName,
                    Time = DateTime.Now,
                    WebAPIURL = _webapiURL
                },
                EnvWebAPI = apienv
            };
            ViewData["Message"] = "Your application description page.";

            return View(viewmodel);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
