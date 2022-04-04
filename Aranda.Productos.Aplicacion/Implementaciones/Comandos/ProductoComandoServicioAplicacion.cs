using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System;

namespace Aranda.Productos.Aplicacion.Implementaciones.Comandos
{
    internal class ProductoComandoServicioAplicacion : IProductoComandoServicioAplicacion
    {
        private readonly ILogger _logger;
        private readonly IProductoComandoRepositorio _productoComandoRepositorio;
        public ProductoComandoServicioAplicacion(ILogger<ProductoComandoServicioAplicacion> logger, IProductoComandoRepositorio productoComandoRepositorio)
        {
            _logger = logger;
            _productoComandoRepositorio = productoComandoRepositorio;
        }

        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                _productoComandoRepositorio.Actualizar(producto);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool CrearProducto(Producto producto)
        {
            try
            {
                producto.Id_Producto = 0;

                _productoComandoRepositorio.Actualizar(producto);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool EliminarProducto(Producto producto)
        {
            try
            {
                _productoComandoRepositorio.Eliminar(producto);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
