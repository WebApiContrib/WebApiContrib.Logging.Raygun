using System.Reflection;

namespace WebApiContrib.Logging.Raygun
{
    public class WebApiRaygunClientMessage
    {
        public WebApiRaygunClientMessage()
        {
            Name = "WebApiContrib.Logging.Raygun";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ClientUrl = @"https://github.com/WebApiContrib/WebApiContrib.Logging.Raygun";
        }

        public string Name { get; set; }

        public string Version { get; set; }

        public string ClientUrl { get; set; }
    }
}