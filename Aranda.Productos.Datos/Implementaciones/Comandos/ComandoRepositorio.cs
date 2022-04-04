using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Microsoft.EntityFrameworkCore;
using System;

namespace Aranda.Productos.Datos.Implementaciones.Comandos
{
    internal class ComandoRepositorio<T> : IDisposable, IComandoRepositorio<T> where T : class
    {
        protected readonly DbContext _Contexto;
        public ComandoRepositorio(IProductosContexto contexto)
        {
            _Contexto = contexto as DbContext;
        }
        public void Dispose()
        {
            _Contexto.Dispose();
        }

        public void Actualizar(T obj)
        {
            _Contexto.Entry(obj).State = EntityState.Modified;
            _Contexto.SaveChanges();
        }

        public void Crear(T obj)
        {
            _Contexto.Entry(obj).State = EntityState.Added;
            _Contexto.SaveChanges();
        }

        public void Eliminar(T obj)
        {
            _Contexto.Entry(obj).State = EntityState.Deleted;
            _Contexto.SaveChanges();
        }
    }
}
