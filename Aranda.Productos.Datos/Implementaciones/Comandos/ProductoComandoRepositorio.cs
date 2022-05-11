using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Aranda.Productos.Datos.Implementaciones.Comandos
{
    internal class ProductoComandoRepositorio : ComandoRepositorio<Producto>, IProductoComandoRepositorio
    {
        private readonly ILogger _logger;
        public ProductoComandoRepositorio(IProductosContexto contexto, ILogger<ProductoComandoRepositorio> logger) : base(contexto)
        {
            _logger = logger;
        }

        public List<Producto> ObtenerInactivos()
        {
            throw new System.NotImplementedException();
        }
    }
}
