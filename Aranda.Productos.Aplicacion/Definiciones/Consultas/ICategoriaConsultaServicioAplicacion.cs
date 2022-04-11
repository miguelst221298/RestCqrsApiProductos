
using Aranda.Productos.Dominio.Entidades;
using System.Collections.Generic;

namespace Aranda.Productos.Aplicacion.Definiciones.Consultas
{
    public interface ICategoriaConsultaServicioAplicacion
    {
        bool VerificarExistenciaPorId(int id);
        bool VerificarExistenciaPorNombre(string nombre);
        List<Categoria> ObtenerTodo();
    }
}
