using Aranda.Productos.Datos.Implementaciones.Comandos;
using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aranda.Productos.Datos.Mappings
{
    internal class ProductoMapping : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id_Producto);

            builder.Property(x => x.Id_Producto).HasColumnName("Id_Producto");
            builder.Property(x => x.NomProducto).HasColumnName("Nombre");
            builder.Property(x => x.Descripcion).HasColumnName("Descripcion");
            builder.Property(x => x.CodCategoria).HasColumnName("CodCategoria");
            builder.Property(x => x.Imagen).HasColumnName("Imagen");

        }
    }
}
