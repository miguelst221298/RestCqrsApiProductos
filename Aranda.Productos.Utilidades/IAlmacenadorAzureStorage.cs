using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Aranda.Productos.Utilidades
{
    public interface IAlmacenadorAzureStorage
    {
        Task BorrarArchivo(string contenedor, string ruta);
        Task<string> EditarArchivo(string contenedor, IFormFile archivo, string rutaArchivoAnterior);
        Task<string> GuardarArchivo(string contenedor, IFormFile archivo);
    }
}