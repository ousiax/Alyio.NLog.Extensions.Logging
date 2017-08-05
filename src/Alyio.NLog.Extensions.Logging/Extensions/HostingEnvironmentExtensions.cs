using System.IO;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Config;

namespace Alyio.NLog.Extensions.Logging
{
    /// <summary>
    /// Extension methods for setting up NLog.
    /// </summary>
    public static class HostingEnvironmentExtensions
    {
        /// <summary>
        /// Configure NLog configuration file.
        /// </summary>
        /// <param name="hostingEnv">The <see cref="IHostingEnvironment"/>.</param>
        /// <param name="configFileRelativePath">The configuration file path reletive to the <see cref="IHostingEnvironment.ContentRootPath"/>.</param>
        /// <param name="ignoreErrors">A <see cref="bool"/> value to indicate whether to ignore errors when apply the configuration.</param>
        public static void ConfigureNLog(this IHostingEnvironment hostingEnv, string configFileRelativePath, bool ignoreErrors = false)
        {
            var fileName = Path.Combine(hostingEnv.ContentRootPath, configFileRelativePath);
            LogManager.Configuration = new XmlLoggingConfiguration(fileName, ignoreErrors);
        }
    }
}
