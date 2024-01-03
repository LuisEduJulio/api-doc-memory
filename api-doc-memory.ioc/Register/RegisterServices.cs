using api_doc_memory.application.Services;
using api_doc_memory.domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api_doc_memory.ioc.Register
{
    public static class IocExtensionServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services
                .AddTransient<IPersonService, PersonService>();
        }
    }
}