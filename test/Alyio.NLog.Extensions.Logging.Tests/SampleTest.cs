using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Alyio.NLog.Extensions.Logging.Tests
{
    public class SampleTest
    {
        private readonly TestServer _server;

        public SampleTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables();
            var Configuration = builder.Build();

            var host = new WebHostBuilder()
                .ConfigureServices(new Action<IServiceCollection>(services =>
                {
                    services.AddMvc();
                    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                })).Configure(new Action<IApplicationBuilder>(app =>
                {
                    app.Run(ctx =>
                    {
                        var id = new ClaimsIdentity("HMAC", ClaimTypes.Name, ClaimTypes.Role);
                        id.AddClaim(new Claim(ClaimTypes.Name, "zhangsan@lisi.com"));
                        ctx.User = new ClaimsPrincipal(id);

                        ctx.RequestServices.GetService<ILoggerFactory>().CreateLogger("HELLO").LogInformation("WORLD");

                        return Task.CompletedTask;
                    });
                }))
                .ConfigureLogging(logging =>
                {
                    logging.AddNLog();
                });

            _server = new TestServer(host);
        }

        [Fact]
        public async Task Test1()
        {
            await _server.CreateClient().GetAsync("/");
        }
    }
}
