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
        private static readonly string ApiKey = ConfigurationManager.AppSettings["RaygunAppKey"];

        public async override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(ApiKey))
            {
                var message = new WebApiRaygunMessage
                {
                    Details =
                    {
                        Request = new WebApiRaygunRequestMessage(context.Request),
                        Error = new WebApiRaygunErrorMessage(context.Exception),
                        Environment = new WebApiRaygunEnvironmentMessage(),
                        User = new WebApiRaygunIdentifierMessage(context.RequestContext.Principal.Identity.Name),
                        Client = new WebApiRaygunClientMessage()
                    }
                };

                var client = new HttpClient();
                var msg = new HttpRequestMessage(HttpMethod.Post, "https://api.raygun.io/entries");
                msg.Headers.Add("X-ApiKey", ApiKey);
                msg.Content = new ObjectContent<WebApiRaygunMessage>(message, new JsonMediaTypeFormatter());

                await client.SendAsync(msg, cancellationToken);
            }
        }
    }
}