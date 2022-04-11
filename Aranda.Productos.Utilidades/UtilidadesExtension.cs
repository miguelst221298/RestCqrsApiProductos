using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Productos.Utilidades
{
    public static class UtilidadesExtension
    {
        public static IServiceCollection RegistarUtilidades(this IServiceCollection services)
        {

            services.AddTransient<IAlmacenadorAzureStorage, AlmacenadorAzureStorage>();
            return services;
        }
    }
}
