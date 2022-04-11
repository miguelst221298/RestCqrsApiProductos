using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using System.Threading.Tasks;

namespace Aranda.Productos.Aplicacion.Definiciones.Comandos
{
    public interface IProductoComandoServicioAplicacion
    {
        Task<bool> CrearProducto(ProductoDto productoDto);
        Task<bool> ActualizarProducto(ProductoDto productoEditar, Producto producto);
        bool EliminarProducto(Producto producto);
    }
}
