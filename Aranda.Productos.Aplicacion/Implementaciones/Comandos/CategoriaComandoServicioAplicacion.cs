using Aranda.Productos.Aplicacion.Definiciones.Comandos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System;

namespace Aranda.Productos.Aplicacion.Implementaciones.Comandos
{
    internal class CategoriaComandoServicioAplicacion : ICategoriaComandoServicioAplicacion
    {
        private readonly ILogger _logger;
        private readonly ICategoriaComandoRepositorio _repositorio;
        public CategoriaComandoServicioAplicacion(ILogger<CategoriaComandoServicioAplicacion> logger, ICategoriaComandoRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;  
        }
        public bool CrearCategoria(Categoria categoria)
        {
            try
            {
                _repositorio.Crear(categoria);
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
