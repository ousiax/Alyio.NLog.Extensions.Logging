using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;

namespace Alyio.NLog.Extensions.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory AddNLog(this ILoggerFactory factory)
        {
            factory.AddProvider(new NLoggerProvider());
            return factory;
        }

        public static void ConfigureNLog(this IHostingEnvironment hostingEnv, string configFileRelativePath, bool ignoreErrors = false)
        {
            var fileName = Path.Combine(hostingEnv.ContentRootPath, configFileRelativePath);
            LogManager.Configuration = new XmlLoggingConfiguration(fileName, ignoreErrors);
        }
    }
}
