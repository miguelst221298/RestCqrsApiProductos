using System;
using System.Collections.Generic;
using System.Text;

namespace Aranda.Productos.Dominio.Dto
{
    public class ListadoProductosDto
    {
        public int CantidadRegistros { get; set; }
        public List<ProductoDto> Listado { get; set; }
    }
}
