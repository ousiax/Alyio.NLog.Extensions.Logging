# Alyio.NLog.Extensions.Logging

[Alyio.NLog.Extensions.Logging](https://github.com/qqbuby/Alyio.NLog.Extensions.Logging) provider for [Microsoft.Extensions.Logging](https://github.com/aspnet/Logging). It's based on [NLog](https://github.com/NLog/NLog), and extends two layout renderers `trace_identifier` and `user_identity_name`.

The layout render `trace_identifier` gets the trace identifier of the current HTTP context (i.e. `HttpContext.TraceIdentifier`), and the layout render `user_identity_name` gets the name of the current HTTP context user identity (i.e. `HttpContext.User.Identity.Name`).

To use these HTTP context layout renderers, you must add `IHttpContextAccessor` to the current service collections. For example, you can add the `IHttpContextAccessor` as below:

```cs
services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
```

And then on the `Startup.Cofigure` method, add the following snippet of code,

```cs
app.UseNLogHttpContextLayoutRenderer();
```

The following usage sample about `Startup.cs`:


```cs
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddNLog();
        app.UseNLogHttpContextLayoutRenderer();
    }
}
```
