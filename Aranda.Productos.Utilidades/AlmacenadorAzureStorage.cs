using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Aranda.Productos.Utilidades
{
    public class AlmacenadorAzureStorage : IAlmacenadorAzureStorage
    {
        private string _cadenaConexionAzureStorage = "DefaultEndpointsProtocol=https;AccountName=productosapi;AccountKey=UHnNe5heYphEB4GQqn+o18zJ9LZgGJt7+eIFTEXk4S63HfgxxwXcqCv1asQOu0c1/PC540Qm9otk+AStTAf1NA==;EndpointSuffix=core.windows.net";
        
        public async Task<string> GuardarArchivo(string contenedor, IFormFile archivo)
        {
            var cliente = new BlobContainerClient(_cadenaConexionAzureStorage, contenedor);
            await cliente.CreateIfNotExistsAsync();
            cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var extension = Path.GetExtension(archivo.FileName);
            var archivoNombre = $"{Guid.NewGuid()}{extension}";
            var blob = cliente.GetBlobClient(archivoNombre);
            await blob.UploadAsync(archivo.OpenReadStream());
            return blob.Uri.ToString();

        }

        public async Task BorrarArchivo(string contenedor, string ruta)
        {
            if (string.IsNullOrEmpty(contenedor))
                return;

            var cliente = new BlobContainerClient(_cadenaConexionAzureStorage, contenedor);
            await cliente.CreateIfNotExistsAsync();
            var archivo = Path.GetFileName(ruta);
            var blob = cliente.GetBlobClient(archivo);
            await blob.DeleteIfExistsAsync();
        }


        public async Task<string> EditarArchivo(string contenedor, IFormFile archivo, string rutaArchivoAnterior)
        {
            await BorrarArchivo(contenedor, rutaArchivoAnterior);
            return await GuardarArchivo(contenedor, archivo);
        }
    }
}
