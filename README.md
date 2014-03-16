WebApiContrib.Logging.Raygun
============================

Logging adapter for Mindscape Raygun. Supports all hosts - web, self-host, Owin host. 

## Usage

Register `RaygunExceptionLogger` as your IExceptionLogger.

    config.Services.Add(typeof (IExceptionLogger), new RaygunExceptionLogger());
    
## Note

Some code internalized from [official Raygun .NET client](https://github.com/MindscapeHQ/raygun4net) in order to avoid taking dependency on it (since it's System.Web based).
