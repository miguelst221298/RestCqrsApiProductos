using Aranda.Productos.Dominio.Entidades;
using System.Collections.Generic;

namespace Aranda.Productos.Datos.Definiciones.Comandos
{
    public interface IProductoComandoRepositorio : IComandoRepositorio<Producto>
    {
        List<Producto> ObtenerInactivos();
    }
}
