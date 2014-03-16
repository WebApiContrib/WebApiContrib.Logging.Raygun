namespace WebApiContrib.Logging.Raygun
{
    public class WebApiRaygunIdentifierMessage
    {
        public WebApiRaygunIdentifierMessage(string user)
        {
            Identifier = user;
        }

        public string Identifier { get; private set; }
    }
}