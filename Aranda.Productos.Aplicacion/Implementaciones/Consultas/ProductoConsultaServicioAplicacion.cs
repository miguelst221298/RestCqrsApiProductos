using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aranda.Productos.Aplicacion.Implementaciones.Consultas
{
    internal class ProductoConsultaServicioAplicacion : IProductoConsultaServicioAplicacion
    {
        private readonly ILogger<ProductoConsultaServicioAplicacion> _logger;
        private readonly IProductoConsultaRepositorio _productoConsultaRepositorio;
        public ProductoConsultaServicioAplicacion(ILogger<ProductoConsultaServicioAplicacion> logger, IProductoConsultaRepositorio productoConsultaRepositorio)
        {
            _productoConsultaRepositorio = productoConsultaRepositorio;
            _logger = logger;
        }

        public ProductoDto ObtenerProductoDtoPorId(int id)
        {
            try
            {
                return _productoConsultaRepositorio.ObtenerProductoDtoPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<ListadoProductosDto> ObtenerListadoProductos(FiltrosDto filtros, PaginacionDto paginacionDto)
        {
            try
            {
               return await _productoConsultaRepositorio.ObtenerListadoProductos(filtros,paginacionDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            return null;
            }

        }

        public bool VerificarExistenciaPorId(int id)
        {
            try
            {
                return _productoConsultaRepositorio.ObtenerPor(x => x.Id_Producto == id).Count() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            try
            {
                return _productoConsultaRepositorio.ObtenerPor(x => x.Id_Producto == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
