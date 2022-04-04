using Aranda.Productos.Datos.Mappings;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Productos.Datos.Contextos
{
    internal class ProductosContexto :DbContext, IProductosContexto
    {
        public DbSet<Producto> Producto { get ; set ; }
        public DbSet<Categoria> Categoria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
        }

        public ProductosContexto(DbContextOptions<ProductosContexto> options): base(options)
        {

        }
    }
}
