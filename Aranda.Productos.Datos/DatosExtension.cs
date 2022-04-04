using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Datos.Implementaciones.Comandos;
using Aranda.Productos.Datos.Implementaciones.Consultas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Productos.Datos
{
    public static class DatosExtension
    {
        private const string _CadenaDeConexion = "Data Source=localhost;Initial Catalog=Productos;Persist Security Info=True;User ID=sa;Password=root;";
        public static IServiceCollection RegistrarRepositorios(this IServiceCollection services)
        {
            //Registrar repositorios de comando
            services.AddTransient<IProductoComandoRepositorio, ProductoComandoRepositorio>();
            services.AddTransient<ICategoriaComandoRepositorio, CategoriaComandoRepositorio>();

            //Registrar repositorios de consulta
            services.AddTransient<IProductoConsultaRepositorio, ProductoConsultaRepositorio>();
            services.AddTransient<ICategoriaConsultaRepositorio, CategoriaConsultaRepositorio>();

            //Registrar contextos
            services.AddTransient<IProductosContexto, ProductosContexto>();

            //Configurar contexto con sql server
            services.AddDbContext<ProductosContexto>(dbContextBuilder => dbContextBuilder.UseSqlServer(_CadenaDeConexion));
            return services;
        }
    }
}
