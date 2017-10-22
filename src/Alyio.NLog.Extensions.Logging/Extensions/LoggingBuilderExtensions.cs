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
            builder.AddProvider(new NLoggerProvider());
            return builder;
        }
    }
}
