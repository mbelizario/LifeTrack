using LifeTrack.Domain.Interfaces;
using LifeTrack.Infra.Data.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace LifeTrack.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                        .FromApplicationDependencies(assembly => assembly.GetName().Name.StartsWith("LifeTrack"))
                        .AddClasses(classes => classes.Where(type =>
                            type.Name.EndsWith("Service") || type.Name.EndsWith("Repository")))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            services.AddScoped<IDbConnection>(provider =>
            {
                var factory = provider.GetRequiredService<ISqlConnectionFactory>();
                return factory.CreateConnection();
            });

            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}
