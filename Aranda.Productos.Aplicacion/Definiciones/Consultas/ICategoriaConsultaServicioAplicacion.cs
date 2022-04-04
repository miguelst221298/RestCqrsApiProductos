
namespace Aranda.Productos.Aplicacion.Definiciones.Consultas
{
    public interface ICategoriaConsultaServicioAplicacion
    {
        bool VerificarExistenciaPorId(int id);
        bool VerificarExistenciaPorNombre(string nombre);
    }
}
