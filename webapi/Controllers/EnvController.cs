using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPI_MongoDB.Models;

namespace webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Env")]
    public class EnvController : Controller
    {
        string _setting = "";
        public EnvController(IOptions<Settings> settings)
        {
            _setting = settings.Value.ConnectionString;
        }



        [HttpGet]
        public EnvironmentBE Get()
        {
            return new EnvironmentBE
                        {
                            MachineName = Environment.MachineName,
                            Time = DateTime.Now,
                            MongoConnectionString = _setting
                        };
        }

    }

    public class EnvironmentBE
    {
        public string MachineName { get; set; }
        public DateTime Time { get; set; }

        public string MongoConnectionString { get; set; }
    }
}