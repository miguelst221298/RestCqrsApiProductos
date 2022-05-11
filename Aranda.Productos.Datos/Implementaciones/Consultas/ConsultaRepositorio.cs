using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aranda.Productos.Datos.Implementaciones.Consultas
{
    internal class ConsultaRepositorio<T> : IDisposable, IConsultaRepositorio<T> where T : class
    {
        protected readonly DbContext _Contexto;
        public ConsultaRepositorio(IProductosContexto contexto)
        {
            _Contexto = contexto as DbContext;
        }
        public void Dispose()
        {
            _Contexto.Dispose();
        }

        public IQueryable<T> ObtenerPor(Expression<Func<T, bool>> predicate)
        {
            return _Contexto.Set<T>().Where(predicate);
        }

        public IQueryable<T> ObtenerTodo()
        {
            return _Contexto.Set<T>();
        }
    }
}
