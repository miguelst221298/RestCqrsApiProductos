using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aranda.Productos.Datos.Mappings
{
    internal class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Cateogoria");
            builder.HasKey(x => x.Id_Categoria);

            builder.Property(x => x.Id_Categoria).HasColumnName("Id_Categoria");
            builder.Property(x => x.Nombre).HasColumnName("Nombre");

        }
    }
}
