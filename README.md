WebApiContrib.Logging.Raygun
============================

Logging adapter for Mindscape Raygun. Supports all hosts - web, self-host, Owin host. 

## Usage

Register `RaygunExceptionLogger` as your `IExceptionLogger`.

    config.Services.Add(typeof (IExceptionLogger), new RaygunExceptionLogger("YOUR_API_KEY"));

or

    config.Services.Add(typeof (IExceptionLogger), new RaygunExceptionLogger());

The latter approach requires your Raygun API key to be added as app setting:

    <add key="RaygunAppKey" value="YOUR_API_KEY" />
    
## Note

Some code internalized from [official Raygun .NET client](https://github.com/MindscapeHQ/raygun4net) in order to avoid taking dependency on it (since it's System.Web based).
