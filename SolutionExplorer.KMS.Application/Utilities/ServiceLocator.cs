using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SolutionExplorer.KMS.Application.Utilities
{
    public static class ServiceLocator
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static T GetService<T>()
        {
            if (_httpContextAccessor?.HttpContext == null)
                throw new InvalidOperationException("HttpContext is not available.");

            return _httpContextAccessor.HttpContext.RequestServices.GetService<T>();
        }
    }
}
