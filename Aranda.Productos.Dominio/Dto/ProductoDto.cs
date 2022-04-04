
namespace Aranda.Productos.Dominio.Dto
{
    public class ProductoDto
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CodCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public byte[] Imagen { get; set; }
        public int CantidadTotalRegistros { get; set; }
    }
}
    