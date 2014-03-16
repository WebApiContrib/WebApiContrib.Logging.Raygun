namespace WebApiContrib.Logging.Raygun
{
    public class WebApiRaygunMessageDetails
    {
        public string MachineName { get; set; }

        public string Version { get; set; }

        public WebApiRaygunErrorMessage Error { get; set; }

        public WebApiRaygunEnvironmentMessage Environment { get; set; }

        public WebApiRaygunIdentifierMessage User { get; set; }

        public WebApiRaygunRequestMessage Request { get; set; }

        public WebApiRaygunClientMessage Client { get; set; }
    }
}