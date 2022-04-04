using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Aranda.Productos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICategoriaComandoServicioAplicacion _categoriaComandoServicioAplicacion;
        private readonly ICategoriaConsultaServicioAplicacion _categoriaConsultaServicioAplicacion;
        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaComandoServicioAplicacion categoriaComandoServicioAplicacion,
            ICategoriaConsultaServicioAplicacion categoriaCpnsultaServicioAplicacion)
        {
            _logger = logger;
            _categoriaComandoServicioAplicacion = categoriaComandoServicioAplicacion;
            _categoriaConsultaServicioAplicacion = categoriaCpnsultaServicioAplicacion;
        }


        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<bool>> Crear([FromBody] Categoria categoria)
        {
            try
            {
                if (_categoriaConsultaServicioAplicacion.VerificarExistenciaPorNombre(categoria.Nombre))
                    return BadRequest($"Ya existe una categoria llamada {categoria.Nombre}");

                return Ok(await Task.Run(() => _categoriaComandoServicioAplicacion.CrearCategoria(categoria)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
