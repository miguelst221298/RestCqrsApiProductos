using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aranda.Productos.Datos.Implementaciones.Consultas
{
    internal class ProductoConsultaRepositorio : ConsultaRepositorio<Producto>, IProductoConsultaRepositorio
    {
        private readonly ILogger _logger;
        public ProductoConsultaRepositorio(IProductosContexto contexto, ILogger<ProductoConsultaRepositorio> logger) : base(contexto)
        {
            _logger = logger;
        }

        public ListadoProductosDto ObtenerListadoProductos(FiltrosDto filtros)
        {
            var resultado = new ListadoProductosDto
            {
                CantidadRegistros = 0,
                Listado = new List<ProductoDto>()
            };

            try
            {
                var contexto = _Contexto as IProductosContexto;
                if (contexto != null)
                {
                    var predicado = from producto in contexto.Producto
                                    join categoria in contexto.Categoria on producto.Id_Producto equals categoria.Id_Categoria
                                    select new ProductoDto
                                    {
                                        Id_Producto = producto.Id_Producto,
                                        Nombre = producto.Nombre,
                                        CodCategoria = categoria.Id_Categoria,
                                        NombreCategoria = categoria.Nombre,
                                        Imagen = producto.Imagen,
                                        Descripcion = producto.Descripcion
                                    };
                    if (filtros.CodCategoria > 0)
                        predicado = predicado.Where(x => x.CodCategoria == filtros.CodCategoria);

                    if (!string.IsNullOrEmpty(filtros.TextoBuscar))
                        predicado = predicado.Where(x =>
                        x.Nombre.ToUpper().Contains(filtros.TextoBuscar.ToUpper()) ||
                        x.Descripcion.ToUpper().Contains(filtros.TextoBuscar.ToUpper()) ||
                        x.NombreCategoria.ToUpper().Contains(filtros.TextoBuscar.ToUpper()));


                    if (filtros.Orden.ToUpper().Contains("CATEGORIA"))
                    {
                        if (filtros.Orden.ToUpper().Contains("DESC"))
                            predicado = predicado.OrderByDescending(x => x.NombreCategoria);
                        else
                        {
                            predicado = predicado.OrderBy(x => x.NombreCategoria);
                        }
                    }
                    else
                    {
                        if (filtros.Orden.ToUpper().Contains("DESC"))
                            predicado = predicado.OrderByDescending(x => x.Nombre);
                        else
                        {
                            predicado = predicado.OrderBy(x => x.Nombre);
                        }
                    }

                    resultado.CantidadRegistros = predicado.Count();
                    resultado.Listado = predicado.Skip(filtros.RegistroActual).Take(filtros.CantidadRegistrosAConsultar).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return resultado;
        }
    }
}
