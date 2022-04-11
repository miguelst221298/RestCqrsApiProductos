using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Dominio.Dto;

namespace Aranda.Productos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductoConsultaServicioAplicacion _productoConsultaServicioAplicacion;
        private readonly IProductoComandoServicioAplicacion _productoComandoServicioAplicacion;
        private readonly ICategoriaConsultaServicioAplicacion _categoriaConsultaServicioAplicacion;
        public ProductoController(ILogger<ProductoController> logger, IProductoConsultaServicioAplicacion productoConsultaServicioAplicacion,
            IProductoComandoServicioAplicacion productoComandoServicioAplicacion, ICategoriaConsultaServicioAplicacion categoriaConsultaServicioAplicacion)
        {
            _logger = logger;
            _productoConsultaServicioAplicacion = productoConsultaServicioAplicacion;
            _productoComandoServicioAplicacion = productoComandoServicioAplicacion;
            _categoriaConsultaServicioAplicacion = categoriaConsultaServicioAplicacion;
        }

        [HttpGet]
        [Route("{id}:int")]
        public async Task<ActionResult<ProductoDto>> Get(int id)
        {
            try
            {
                var resultado = await Task.Run(() => _productoConsultaServicioAplicacion.ObtenerProductoDtoPorId(id));
                if (resultado != null)
                    return Ok(resultado);
                else
                    return NotFound($"No existe el producto con id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromForm] ProductoDto productoDto)
        {
            try
            {
                if (!_categoriaConsultaServicioAplicacion.VerificarExistenciaPorId(productoDto.CodCategoria))
                    return BadRequest($"No existe la categoria id: {productoDto.CodCategoria}");
             

                return Ok(await Task.Run(() => _productoComandoServicioAplicacion.CrearProducto(productoDto)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}:int")]
        public async Task<ActionResult<bool>> Put(int id, [FromForm] ProductoDto productoEditar)
        {
            try
            {
                    var producto = _productoConsultaServicioAplicacion.ObtenerProductoPorId(id);
                    if (producto == null)
                        return NotFound($"No existe el producto con id: {productoEditar.Id_Producto}");

                    if (!_categoriaConsultaServicioAplicacion.VerificarExistenciaPorId(productoEditar.CodCategoria))
                        return BadRequest($"No existe la categoria id: {productoEditar.CodCategoria}");

                    return Ok(await Task.Run(() => _productoComandoServicioAplicacion.ActualizarProducto(productoEditar, producto)));
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}:int")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                Producto producto = _productoConsultaServicioAplicacion.ObtenerProductoPorId(id);
                if (producto != null)
                    return Ok(await Task.Run(() => _productoComandoServicioAplicacion.EliminarProducto(producto)));
                else
                    return NotFound($"No existe el producto con id: {producto.Id_Producto}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


    }
}
