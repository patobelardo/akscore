using System;

namespace frontend_mvc.Models
{
    public class EnvironmentBE
    {
        public string MachineName { get; set; }
        public DateTime Time { get; set; }

        public string MongoConnectionString { get; set; }
        public string WebAPIURL { get; set; }
    }
}