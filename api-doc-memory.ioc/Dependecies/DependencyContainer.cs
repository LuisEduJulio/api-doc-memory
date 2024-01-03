using api_doc_memory.application.Validators;
using api_doc_memory.infraestructure.Entities;
using api_doc_memory.infraestructure.Factory;
using api_doc_memory.ioc.Register;
using api_doc_memory.utility.Helpers;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace api_doc_memory.ioc.Dependecies
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterIocDependencies(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services
               .AddMvc();

            Services
               .AddHttpClient();

            Services
                .AddControllers();

            Services
               .RegisterAutoMappers();

            Services
                .RegisterRepositories();

            Services
                .RegisterServices();

            Services
                .AddLogging();

            Services
            .AddFluentValidation(fv => fv
                .RegisterValidatorsFromAssemblyContaining<PersonAddDtoValidator>());

            Services
                .Configure<AppSettings>(Configuration);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            Services.AddDbContext<AppDbContext>(options => options
                .UseInMemoryDatabase("MemoryDatabase")
                .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            // Adicionar dados iniciais (opcional)
            //Services.AddTransient<IDataInitializer, DataInitializer>();

            var appSettings = configuration.Get<AppSettings>();

            Services.AddCors(c =>
            {
                c.AddPolicy(EnvironmentHelper.GetCross(),
                    options => options
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(EnvironmentHelper.GetVersionApi(),
                    new OpenApiInfo
                    {
                        Title = EnvironmentHelper.GetApplicationName(),
                        Version = EnvironmentHelper.GetVersionApi()
                    });
            });

            Services.AddEndpointsApiExplorer();

            Services.AddAuthorization();

            return Services;
        }
    }
}