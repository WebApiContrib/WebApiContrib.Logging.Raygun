using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApiContrib.Logging.Raygun
{
    public class RaygunExceptionLogger : ExceptionLogger
    {
        private readonly string _apiKey;

        public RaygunExceptionLogger() : this(ConfigurationManager.AppSettings["RaygunAppKey"])
        {}

        public RaygunExceptionLogger(string apiKey)
        {
            if (apiKey == null) throw new ArgumentNullException("apiKey");
            _apiKey = apiKey;
        }

        public async override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                var message = new WebApiRaygunMessage
                {
                    Details =
                    {
                        Request = new WebApiRaygunRequestMessage(context.Request),
                        Error = new WebApiRaygunErrorMessage(context.Exception),
                        Environment = new WebApiRaygunEnvironmentMessage(),
                        User = new WebApiRaygunIdentifierMessage(context.RequestContext != null && context.RequestContext.Principal != null ? context.RequestContext.Principal.Identity.Name : "Anonymous"),
                        Client = new WebApiRaygunClientMessage()
                    }
                };

                var client = new HttpClient();
                var msg = new HttpRequestMessage(HttpMethod.Post, "https://api.raygun.io/entries");
                msg.Headers.Add("X-ApiKey", _apiKey);
                msg.Content = new ObjectContent<WebApiRaygunMessage>(message, new JsonMediaTypeFormatter());

                await client.SendAsync(msg, cancellationToken);
            }
        }
    }
}