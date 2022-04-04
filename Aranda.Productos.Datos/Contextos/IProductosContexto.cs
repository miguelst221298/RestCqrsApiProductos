using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Productos.Datos.Contextos
{
    public interface IProductosContexto 
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
