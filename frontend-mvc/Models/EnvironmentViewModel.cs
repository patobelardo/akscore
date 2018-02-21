using System;

namespace frontend_mvc.Models
{
    public class EnvironmentViewModel
    {
        public EnvironmentBE EnvFrontEnd { get; set; }
        public EnvironmentBE EnvWebAPI { get; set; }
    }
}