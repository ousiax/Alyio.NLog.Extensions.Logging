using Microsoft.AspNetCore.Builder;

namespace Alyio.NLog.Extensions.Logging
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNLogHttpContextLayoutRenderer(this IApplicationBuilder appBuilder)
        {
            ServiceLocator.ServiceProvider = appBuilder.ApplicationServices;
            return appBuilder;
        }
    }
}
