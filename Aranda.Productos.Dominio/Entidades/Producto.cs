
namespace Aranda.Productos.Dominio.Entidades
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CodCategoria { get; set; }
        public byte[] Imagen { get; set; }
    }
}
