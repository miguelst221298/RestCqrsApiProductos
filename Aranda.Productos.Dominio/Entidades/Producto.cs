
using System.ComponentModel.DataAnnotations;

namespace Aranda.Productos.Dominio.Entidades
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string NomProducto { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Descripcion { get; set; }
        [Required]
        public int CodCategoria { get; set; }
        [StringLength(maximumLength: 500)]
        public string Imagen { get; set; }
    }
}
