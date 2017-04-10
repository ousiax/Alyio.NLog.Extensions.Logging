using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NLog.LayoutRenderers;

namespace Alyio.NLog.Extensions.Logging.LayoutRenderers
{
    public abstract class HttpContextLayoutRendererBase : LayoutRenderer
    {
        private IHttpContextAccessor _httpContextAccessor;

        protected IHttpContextAccessor HttpContextAccessor { get { return _httpContextAccessor ?? (_httpContextAccessor = ServiceLocator.ServiceProvider.GetService<IHttpContextAccessor>()); } }
    }
}
