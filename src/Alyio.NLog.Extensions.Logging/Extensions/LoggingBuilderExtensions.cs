using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Alyio.NLog.Extensions.Logging
{
    /// <summary>
    /// Extension methods for setting up logging service in an <see cref="ILoggingBuilder"/>
    /// </summary>
    public static class LoggingBuilderExtensions
    {
        /// <summary>
        /// Add a NLog provider.
        /// </summary>
        /// <param name="builder"><see cref="ILoggingBuilder"/>.</param>
        /// <returns><see cref="ILoggingBuilder"/></returns>
        public static ILoggingBuilder AddNLog(this ILoggingBuilder builder)
        {
            return builder.AddNLog("nlog.config", false);
        }

        /// <summary>
        /// Add a NLog provider.
        /// </summary>
        /// <param name="builder"><see cref="ILoggingBuilder"/>.</param>
        /// <param name="configFileRelativePath">The configuration file path reletive to the <see cref="IHostingEnvironment.ContentRootPath"/>.</param>
        /// <param name="ignoreErrors">A <see cref="bool"/> value to indicate whether to ignore errors when apply the configuration.</param>
        /// <returns><see cref="ILoggingBuilder"/></returns>
        public static ILoggingBuilder AddNLog(this ILoggingBuilder builder, string configFileRelativePath, bool ignoreErrors = false)
        {
            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ServiceLocator.ServiceProvider = builder.Services.BuildServiceProvider();

            var hostingEnv = ServiceLocator.ServiceProvider.GetService<IHostingEnvironment>();
            var fileName = Path.Combine(hostingEnv.ContentRootPath, configFileRelativePath);

            builder.AddProvider(new NLoggerProvider(fileName, ignoreErrors));

            return builder;
        }
    }
}
