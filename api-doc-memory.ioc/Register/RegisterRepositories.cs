using api_doc_memory.domain.Repositories;
using api_doc_memory.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace api_doc_memory.ioc.Register
{
    public static class IocExtensionRepositories
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}