using System.Linq;
using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace Alyio.NLog.Extensions.Logging.LayoutRenderers
{
    /// <summary>
    /// Represent a unique identifier to represent a request from the request HTTP header X-Request-Id.
    /// </summary>
    [LayoutRenderer("x_request_id")]
    public class XRequestIdLayoutRender : HttpContextLayoutRendererBase
    {
        /// <inheritdoc />
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var identityName = HttpContextAccessor.HttpContext?.Request?.Headers?["X-Request-Id"].FirstOrDefault();
            builder.Append(identityName);
        }
    }
}
