using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aranda.Productos.Datos.Definiciones.Consultas
{
    public interface IConsultaRepositorio<T>
    {
        IQueryable<T> ObtenerPor(Expression<Func<T, bool>> predicate);
        IQueryable<T> ObtenerTodo();
    }
}
