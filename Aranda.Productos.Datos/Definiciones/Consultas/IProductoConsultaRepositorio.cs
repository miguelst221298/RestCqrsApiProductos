using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using System.Collections.Generic;

namespace Aranda.Productos.Datos.Definiciones.Consultas
{
    public interface IProductoConsultaRepositorio : IConsultaRepositorio<Producto>
    {
        ListadoProductosDto ObtenerListadoProductos(FiltrosDto filtros);
    }
}
