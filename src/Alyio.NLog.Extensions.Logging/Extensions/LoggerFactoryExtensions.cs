using Microsoft.Extensions.Logging;

namespace Alyio.NLog.Extensions.Logging
{
    /// <summary>
    /// Extension methods for the <see cref="ILoggerFactory"/> class.
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// Adds a NLog logger.
        /// </summary>
        public static ILoggerFactory AddNLog(this ILoggerFactory factory)
        {
            factory.AddProvider(new NLoggerProvider());
            return factory;
        }
    }
}
