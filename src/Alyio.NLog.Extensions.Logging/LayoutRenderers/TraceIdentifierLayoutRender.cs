using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace Alyio.NLog.Extensions.Logging.LayoutRenderers
{
    [LayoutRenderer("trace_identifier")]
    public sealed class TraceIdentifierLayoutRender : HttpContextLayoutRendererBase
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var traceIdentifier = HttpContextAccessor.HttpContext?.TraceIdentifier;
            builder.Append(traceIdentifier);
        }
    }
}
