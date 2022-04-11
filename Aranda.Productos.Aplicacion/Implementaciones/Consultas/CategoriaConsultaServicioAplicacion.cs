using Aranda.Productos.Aplicacion.Definiciones.Consultas;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aranda.Productos.Aplicacion.Implementaciones.Consultas
{
    internal class CategoriaConsultaServicioAplicacion : ICategoriaConsultaServicioAplicacion
    {
        private readonly ILogger _logger;
        private readonly ICategoriaConsultaRepositorio _categoriaConsultaRepositorio;
        public CategoriaConsultaServicioAplicacion(ILogger<ProductoConsultaServicioAplicacion> logger, ICategoriaConsultaRepositorio categoriaConsultaRepositorio)
        {
            _categoriaConsultaRepositorio = categoriaConsultaRepositorio;
            _logger = logger;
        }

        public List<Categoria> ObtenerTodo()
        {
            try
            {
                return _categoriaConsultaRepositorio.ObtenerTodo().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Categoria>();
            }
        }

        public bool VerificarExistenciaPorId(int id)
        {
            try
            {
                return _categoriaConsultaRepositorio.ObtenerPor(x => x.id_Categoria == id).Count() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool VerificarExistenciaPorNombre(string nombre)
        {
            try
            {
                return _categoriaConsultaRepositorio.ObtenerPor(x => x.nomCategoria.ToUpper() == nombre.ToUpper()).Count() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
