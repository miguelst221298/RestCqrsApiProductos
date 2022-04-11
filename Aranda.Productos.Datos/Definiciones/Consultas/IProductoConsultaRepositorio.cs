using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Productos.Datos.Definiciones.Consultas
{
    public interface IProductoConsultaRepositorio : IConsultaRepositorio<Producto>
    {
        Task<ListadoProductosDto> ObtenerListadoProductos(FiltrosDto filtros, PaginacionDto paginacionDto);
        ProductoDto ObtenerProductoDtoPorId(int id);
    }
}
