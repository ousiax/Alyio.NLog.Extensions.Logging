using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace Alyio.NLog.Extensions.Logging.LayoutRenderers
{
    [LayoutRenderer("user_identity_name")]
    public class UserIdentityLayoutRender : HttpContextLayoutRendererBase
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var identityName = HttpContextAccessor.HttpContext?.User?.Identity?.Name;
            builder.Append(identityName);
        }
    }
}
