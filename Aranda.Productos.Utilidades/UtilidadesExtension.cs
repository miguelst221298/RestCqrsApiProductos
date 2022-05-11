using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Productos.Utilidades
{
    public static class UtilidadesExtension
    {
        public static IServiceCollection RegistarUtilidades(this IServiceCollection services)
        {
            //asdasd prueba push
            services.AddTransient<IAlmacenadorAzureStorage, AlmacenadorAzureStorage>();
            return services;
        }
    }
}
