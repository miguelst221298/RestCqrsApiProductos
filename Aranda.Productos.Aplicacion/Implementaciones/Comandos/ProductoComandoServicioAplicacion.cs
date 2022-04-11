using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using Aranda.Productos.Utilidades;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Aranda.Productos.Aplicacion.Implementaciones.Comandos
{
    internal class ProductoComandoServicioAplicacion : IProductoComandoServicioAplicacion
    {
        private readonly ILogger _logger;
        private readonly IProductoComandoRepositorio _productoComandoRepositorio;
        private readonly IAlmacenadorAzureStorage _almacenadorAzureStorage;
        private readonly string _contenedorImagenes = "productos";
        public ProductoComandoServicioAplicacion(ILogger<ProductoComandoServicioAplicacion> logger, IProductoComandoRepositorio productoComandoRepositorio,
            IAlmacenadorAzureStorage almacenadorAzureStorage)
        {
            _logger = logger;
            _productoComandoRepositorio = productoComandoRepositorio;
            _almacenadorAzureStorage = almacenadorAzureStorage;
        }


        public async Task<bool> ActualizarProducto(ProductoDto productoEditar, Producto producto)
        {
            try
            {
                producto.Descripcion = productoEditar.Descripcion;
                producto.NomProducto= productoEditar.NomProducto;
                producto.CodCategoria = productoEditar.CodCategoria;

                if(productoEditar.Imagen!=null)
                    producto.Imagen= await _almacenadorAzureStorage.EditarArchivo(_contenedorImagenes, productoEditar.Imagen, producto.Imagen);

                _productoComandoRepositorio.Actualizar(producto);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> CrearProducto(ProductoDto productoDto)
        {
            try
            {
                var producto = new Producto
                {
                    Id_Producto = 0,
                    NomProducto = productoDto.NomProducto,
                    Descripcion = productoDto.Descripcion,
                    CodCategoria = productoDto.CodCategoria
                };


                if (productoDto.Imagen != null)
                {
                    producto.Imagen= await _almacenadorAzureStorage.GuardarArchivo(_contenedorImagenes,productoDto.Imagen);
                }

                _productoComandoRepositorio.Crear(producto);
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
