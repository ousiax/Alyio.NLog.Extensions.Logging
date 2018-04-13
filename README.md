# Alyio.NLog.Extensions.Logging

[Alyio.NLog.Extensions.Logging](https://github.com/qqbuby/Alyio.NLog.Extensions.Logging) provider for [Microsoft.Extensions.Logging](https://github.com/aspnet/Logging). It's based on [NLog](https://github.com/NLog/NLog), and extends two layout renderers `trace_identifier` and `user_identity_name`.

The layout render `trace_identifier` gets the trace identifier of the current HTTP context (i.e. `HttpContext.TraceIdentifier`), and the layout render `user_identity_name` gets the name of the current HTTP context user identity (i.e. `HttpContext.User.Identity.Name`).

## ASP.NET Core 2.x

To use NLog provider, call the provider's AddNLog extension method in `Program.cs`:

```cs
using Alyio.NLog.Extensions.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(configureLogging =>
                {
                    configureLogging.AddNLog();
                })
                .UseStartup<Startup>()
                .Build();
    }
}
```
