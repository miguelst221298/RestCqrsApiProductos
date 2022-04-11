using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                return Ok(await Task.Run(() => _categoriaConsultaServicioAplicacion.ObtenerTodo()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] Categoria categoria)
        {
            try
            {
                if (_categoriaConsultaServicioAplicacion.VerificarExistenciaPorNombre(categoria.nomCategoria))
                    return BadRequest($"Ya existe una categoria llamada {categoria.nomCategoria}");

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
