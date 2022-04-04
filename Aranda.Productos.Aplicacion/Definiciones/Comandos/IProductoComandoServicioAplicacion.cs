using Aranda.Productos.Dominio.Entidades;

namespace Aranda.Productos.Aplicacion.Definiciones.Comandos
{
    public interface IProductoComandoServicioAplicacion
    {
        bool CrearProducto(Producto producto);
        bool ActualizarProducto(Producto producto);
        bool EliminarProducto(Producto producto);
    }
}
