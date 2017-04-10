using System;
using NLog;

namespace Alyio.NLog.Extensions.Logging
{
    sealed class NLogger : Microsoft.Extensions.Logging.ILogger
    {
        private readonly ILogger _logger;

        public NLogger(ILogger logger)
        {
            _logger = logger;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            //TODO not working with async
            return NestedDiagnosticsContext.Push(state);
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            var nlogLevel = ConvertToNLogLevel(logLevel);
            return _logger.IsEnabled(nlogLevel);
        }

        public void Log<TState>(
            Microsoft.Extensions.Logging.LogLevel logLevel,
            Microsoft.Extensions.Logging.EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                if (formatter == null)
                {
                    throw new ArgumentNullException(nameof(formatter));
                }
                var message = formatter(state, exception);

                if (!string.IsNullOrEmpty(message))
                {
                    var nlogLevel = ConvertToNLogLevel(logLevel);
                    var logEvent = LogEventInfo.Create(nlogLevel, _logger.Name, message);
                    logEvent.Exception = exception;
                    logEvent.Properties["EventId.Id"] = eventId.Id;
                    logEvent.Properties["EventId.Name"] = eventId.Name;
                    logEvent.Properties["EventId"] = eventId;
                    _logger.Log(logEvent);
                }
            }
        }

        private static LogLevel ConvertToNLogLevel(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Microsoft.Extensions.Logging.LogLevel.Trace:
                    return LogLevel.Trace;
                case Microsoft.Extensions.Logging.LogLevel.Debug:
                    return LogLevel.Debug;
                case Microsoft.Extensions.Logging.LogLevel.Information:
                    return LogLevel.Info;
                case Microsoft.Extensions.Logging.LogLevel.Warning:
                    return LogLevel.Warn;
                case Microsoft.Extensions.Logging.LogLevel.Error:
                    return LogLevel.Error;
                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    return LogLevel.Fatal;
                case Microsoft.Extensions.Logging.LogLevel.None:
                    return LogLevel.Off;
                default:
                    return LogLevel.Debug;
            }
        }
    }
}
