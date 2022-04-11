
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Aranda.Productos.Dominio.Dto
{
    public class ProductoDto
    {
        public int Id_Producto { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string NomProducto { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Descripcion { get; set; }
        public int CodCategoria { get; set; }
        public string NomCategoria { get; set; }
        public IFormFile Imagen { get; set; }
        public string UrlImagen { get; set; }

    }
}
