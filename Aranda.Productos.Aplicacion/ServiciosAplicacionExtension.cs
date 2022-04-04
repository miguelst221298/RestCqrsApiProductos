using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Aplicacion.Implementaciones.Comandos;
using Aranda.Productos.Aplicacion.Implementaciones.Consultas;
using Aranda.Productos.Datos;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Productos.Aplicacion
{
    public static class ServiciosAplicacionExtension
    {
        public static IServiceCollection RegistrarServicios( this IServiceCollection services)
        {

            //Registrar servicios de comando
            services.AddTransient<IProductoComandoServicioAplicacion, ProductoComandoServicioAplicacion>();
            services.AddTransient<ICategoriaComandoServicioAplicacion, CategoriaComandoServicioAplicacion>();

            //Registrar servicios de consulta
            services.AddTransient<IProductoConsultaServicioAplicacion, ProductoConsultaServicioAplicacion>();


            services.RegistrarRepositorios();
            return services;
        }
    }
}
