using LifeTrack.Infra.CrossCutting.IoC;

namespace LifeTrack.UI.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services) 
        {
            if(services == null) throw new ArgumentNullException(nameof(services));
            NativeInjectorBootStrapper.RegisterServices(services);
            return services;
        }
    }
}
