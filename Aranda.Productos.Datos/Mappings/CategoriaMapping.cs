using Aranda.Productos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aranda.Productos.Datos.Mappings
{
    internal class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(x => x.id_Categoria);

            builder.Property(x => x.id_Categoria).HasColumnName("Id_Categoria");
            builder.Property(x => x.nomCategoria).HasColumnName("Nombre");

        }
    }
}
