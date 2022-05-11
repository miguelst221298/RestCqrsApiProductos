using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Dto;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aranda.Productos.Datos.Implementaciones.Consultas
{
    internal class ProductoConsultaRepositorio : ConsultaRepositorio<Producto>, IProductoConsultaRepositorio
    {
        private readonly ILogger _logger;
        public ProductoConsultaRepositorio(IProductosContexto contexto, ILogger<ProductoConsultaRepositorio> logger) : base(contexto)
        {
            _logger = logger;
        }

        public async Task<ListadoProductosDto> ObtenerListadoProductos(FiltrosDto filtros, PaginacionDto paginacionDto)
        {
            var resultado = new ListadoProductosDto
            {
                TotalRegistros = 0,
                Listado = new List<ProductoDto>()
            };

            try
            {
                var contexto = _Contexto as IProductosContexto;
                if (contexto != null)
                {
                    var predicado = from producto in contexto.Producto
                                    join categoria in contexto.Categoria on producto.CodCategoria equals categoria.id_Categoria
                                    select new ProductoDto
                                    {
                                        Id_Producto = producto.Id_Producto,
                                        NomProducto = producto.NomProducto,
                                        NomCategoria = categoria.nomCategoria,
                                        CodCategoria=categoria.id_Categoria
                                    };
                    if (filtros.CodCategoria > 0)
                        predicado = predicado.Where(x => x.CodCategoria == filtros.CodCategoria);

                    if (!string.IsNullOrEmpty(filtros.Nombre))
                        predicado = predicado.Where(x =>
                        x.NomProducto.ToUpper().Contains(filtros.Nombre.ToUpper()));

                    if (!string.IsNullOrEmpty(filtros.Descripcion))
                        predicado = predicado.Where(x =>
                        x.NomProducto.ToUpper().Contains(filtros.Descripcion.ToUpper()));

                    if (filtros.Orden.ToUpper().Contains("CATEGORIA"))
                    {
                        if (filtros.Orden.ToUpper().Contains("DESC"))
                            predicado = predicado.OrderByDescending(x => x.NomCategoria);
                        else
                        {
                            predicado = predicado.OrderBy(x => x.NomCategoria);
                        }
                    }
                    else
                    {
                        if (filtros.Orden.ToUpper().Contains("DESC"))
                            predicado = predicado.OrderByDescending(x => x.NomProducto);
                        else
                        {
                            predicado = predicado.OrderBy(x => x.NomProducto);
                        }
                    }

                    resultado.TotalRegistros = await predicado.CountAsync();
                    resultado.Listado =  await predicado.Skip((paginacionDto.Pagina-1) * paginacionDto.CantidadRegistrosAConsultar).Take(paginacionDto.CantidadRegistrosAConsultar).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return resultado;
        }

        public List<Producto> ObtenerLosQueEmpiezanConA()
        {
            return ObtenerPor(x => x.NomProducto.ToLower().StartsWith("a")).ToList();
        }

        public ProductoDto ObtenerProductoDtoPorId(int id)
        {
            var contexto = _Contexto as IProductosContexto;
            if (contexto != null)
            {

                return (from producto in contexto.Producto
                       join categoria in contexto.Categoria
                       on producto.CodCategoria equals categoria.id_Categoria
                       where producto.Id_Producto==id
                       select new ProductoDto
                       {
                           Id_Producto = producto.Id_Producto,
                           CodCategoria = categoria.id_Categoria,
                           NomCategoria = categoria.nomCategoria,
                           NomProducto = producto.NomProducto,
                           Descripcion = producto.Descripcion,
                           UrlImagen = producto.Imagen
                       }).FirstOrDefault();
            }
            else
            {
                return null;
            }

        }
    }
}
