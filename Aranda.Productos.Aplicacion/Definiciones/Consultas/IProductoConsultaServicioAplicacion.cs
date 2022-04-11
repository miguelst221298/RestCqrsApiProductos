using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using System.Threading.Tasks;

namespace Aranda.Productos.Aplicacion.Definiciones.Consultas
{
    public interface IProductoConsultaServicioAplicacion
    {
        Task<ListadoProductosDto> ObtenerListadoProductos(FiltrosDto filtros, PaginacionDto paginacionDto);
        ProductoDto ObtenerProductoDtoPorId(int id);
        Producto ObtenerProductoPorId(int id);
        bool VerificarExistenciaPorId(int id);
    }
}
