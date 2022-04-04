using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Dominio.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Productos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListadoProductosController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductoConsultaServicioAplicacion _productoConsultaServicioAplicacion;

        public ListadoProductosController(ILogger<ListadoProductosController> logger, IProductoConsultaServicioAplicacion productoConsultaServicioAplicacion)
        {
            _logger = logger;
            _productoConsultaServicioAplicacion = productoConsultaServicioAplicacion;
        }
        //Pasar esto al ListadoProductosController
        [HttpPost]
        [Route("ObtenerListadoProductos")]
        public async Task<ActionResult<ListadoProductosDto>> ObtenerListadoProductos([FromBody] FiltrosDto filtros)
        {
            try
            {
                return Ok(await Task.Run(() => _productoConsultaServicioAplicacion.ObtenerListadoProductos(filtros)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new ListadoProductosDto
                {
                    CantidadRegistros = 0,
                    Listado = new List<ProductoDto>()
                });
            }
        }
    }
}
