# Alyio.NLog.Extensions.Logging

[Alyio.NLog.Extensions.Logging](https://github.com/qqbuby/Alyio.NLog.Extensions.Logging) provider for [Microsoft.Extensions.Logging](https://github.com/aspnet/Logging). It's based on [NLog.Extensions.Logging](https://github.com/NLog/NLog.Extensions.Logging), and extends two *layout renderers* `trace_identifier` and `user_identity_name`.

The layout render `trace_identifier` gets the trace identifier of the current http context (i.e. `HttpContext.TraceIdentifier`), and the layout render `user_identity_name` gets the name of the current http context user identity (i.e. `HttpContext.User.Identity.Name`).

To use these http context layout renderers, you MUST add `IHttpContextAccessor` to the current service collections. For example, you can add the `IHttpContextAccessor` as follows:

```cs
services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
```

And then on the `Startup.Cofigure` method, add the follow codes,

```cs
app.UseNLogHttpContextLayoutRenderer();
```
Here is the usage sample about `Startup.cs`.

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
