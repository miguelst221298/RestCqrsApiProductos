
using System.ComponentModel.DataAnnotations;

namespace Aranda.Productos.Dominio.Entidades
{
    public class Categoria
    {
        public int id_Categoria { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string nomCategoria { get; set; }
    }
}
