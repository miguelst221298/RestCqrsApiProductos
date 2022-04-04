using Aranda.Productos.Datos.Contextos;
using Aranda.Productos.Datos.Definiciones.Comandos;
using Aranda.Productos.Dominio.Entidades;

namespace Aranda.Productos.Datos.Implementaciones.Comandos
{
    internal class CategoriaComandoRepositorio : ComandoRepositorio<Categoria>, ICategoriaComandoRepositorio
    {
        public CategoriaComandoRepositorio(IProductosContexto contexto) : base(contexto)
        {
        }
    }
}
