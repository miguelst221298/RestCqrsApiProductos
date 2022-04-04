using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;

namespace Aranda.Productos.Aplicacion.Definiciones.Consultas
{
    public interface IProductoConsultaServicioAplicacion
    {
        ListadoProductosDto ObtenerListadoProductos(FiltrosDto filtros);
        Producto ObtenerProductoPorId(int id);
        bool VerificarExistenciaPorId(int id);
    }
}
