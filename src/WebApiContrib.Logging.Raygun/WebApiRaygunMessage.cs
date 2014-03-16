using System;

namespace WebApiContrib.Logging.Raygun
{
    public class WebApiRaygunMessage
    {
        public WebApiRaygunMessage()
        {
            OccurredOn = DateTime.UtcNow;
            Details = new WebApiRaygunMessageDetails();
        }

        public DateTime OccurredOn { get; set; }

        public WebApiRaygunMessageDetails Details { get; set; }
    }
}