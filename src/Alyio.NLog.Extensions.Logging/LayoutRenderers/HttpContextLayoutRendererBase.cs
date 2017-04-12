using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NLog.LayoutRenderers;

namespace Alyio.NLog.Extensions.Logging.LayoutRenderers
{
    /// <summary>
    /// Represent a http context layout renderer to access the current http context.
    /// </summary>
    public abstract class HttpContextLayoutRendererBase : LayoutRenderer
    {
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Gets the <see cref="IHttpContextAccessor"/>.
        /// </summary>
        protected IHttpContextAccessor HttpContextAccessor { get { return _httpContextAccessor ?? (_httpContextAccessor = ServiceLocator.ServiceProvider.GetService<IHttpContextAccessor>()); } }
    }
}
