using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Aranda.Productos.Aplicacion.Definiciones.Comandos;

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
        [Route("ObtenerProductoPorId/{id}")]
        public async Task<ActionResult<Producto>> ObtenerProductoPorId(int id)
        {
            try
            {
                var resultado = await Task.Run(() => _productoConsultaServicioAplicacion.ObtenerProductoPorId(id));
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
        [Route("CrearProducto")]
        public async Task<ActionResult<bool>> CrearProducto([FromBody] Producto producto)
        {
            try
            {
                if (!_categoriaConsultaServicioAplicacion.VerificarExistenciaPorId(producto.CodCategoria))
                    return BadRequest($"No existe la categoria id: {producto.CodCategoria}");

                return Ok(await Task.Run(() => _productoComandoServicioAplicacion.CrearProducto(producto)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("ActualizarProducto/{id}")]
        public async Task<ActionResult<bool>> ActualizarProducto(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id == producto.Id_Producto && id > 0)
                {
                    if (!_productoConsultaServicioAplicacion.VerificarExistenciaPorId(producto.Id_Producto))
                        return NotFound($"No existe el producto con id: {producto.Id_Producto}");

                    if (!_categoriaConsultaServicioAplicacion.VerificarExistenciaPorId(producto.CodCategoria))
                        return BadRequest($"No existe la categoria id: {producto.CodCategoria}");

                    return Ok(await Task.Run(() => _productoComandoServicioAplicacion.ActualizarProducto(producto)));
                }
                else
                    return BadRequest("El endpoint no coincide con el id del producto a actualizar");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("EliminarProducto/{id}")]
        public async Task<ActionResult<bool>> EliminarProducto(int id)
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
