using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Productos.Utilidades
{
    public static class UtilidadesExtension
    {
        public static IServiceCollection RegistarUtilidades(this IServiceCollection services)
        {
            //Aca coloco otra cosa de conflicos
            services.AddTransient<IAlmacenadorAzureStorage, AlmacenadorAzureStorage>();
            return services;
        }
    }
}
