using System.Reflection;
using NLog;
using NLog.Config;

namespace Alyio.NLog.Extensions.Logging
{
    sealed class NLoggerProvider : Microsoft.Extensions.Logging.ILoggerProvider
    {
        public NLoggerProvider()
        {
            ConfigurationItemFactory.Default.RegisterItemsFromAssembly(this.GetType().GetTypeInfo().Assembly);
            LogManager.Configuration = new XmlLoggingConfiguration("nlog.config", false);
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return new NLogger(LogManager.GetLogger(categoryName));
        }

        public void Dispose()
        {
        }
    }
}
