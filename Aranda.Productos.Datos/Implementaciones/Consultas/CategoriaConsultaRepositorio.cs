using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Consultas;
using Aranda.Productos.Dominio.Entidades;
using System.Linq;

namespace Aranda.Productos.Datos.Implementaciones.Consultas
{
    internal class CategoriaConsultaRepositorio : ConsultaRepositorio<Categoria>, ICategoriaConsultaRepositorio
    {
        public CategoriaConsultaRepositorio(IProductosContexto contexto) : base(contexto)
        {
        }

    }
}
