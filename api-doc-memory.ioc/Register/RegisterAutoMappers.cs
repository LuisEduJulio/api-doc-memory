using api_doc_memory.application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace api_doc_memory.ioc.Register
{
    public static class IocExtensionAutoMappers
    {
        public static void RegisterAutoMappers(this IServiceCollection services)
        {
            services
                 .AddAutoMapper(typeof(MapperPersonProfile));
        }
    }
}