using Microsoft.AspNetCore.Builder;

namespace Alyio.NLog.Extensions.Logging
{
    /// <summary>
    /// Extension methods for <see cref="IApplicationBuilder"/>  to add NLog to the request execution pipeline.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        ///  Adds NLogHttpContextLayoutRenderer to the <see cref="IApplicationBuilder"/> request execution pipeline.
        /// </summary>
        /// <param name="appBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNLogHttpContextLayoutRenderer(this IApplicationBuilder appBuilder)
        {
            ServiceLocator.ServiceProvider = appBuilder.ApplicationServices;
            return appBuilder;
        }
    }
}
