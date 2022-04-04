
namespace Aranda.Productos.Datos.Definiciones.Comandos
{
    public interface IComandoRepositorio<T>
    {
        void Crear(T obj);
        void Actualizar(T obj);
        void Eliminar(T obj);
    }
}
