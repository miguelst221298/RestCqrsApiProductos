using System;
using System.Collections.Generic;
using System.Text;

namespace Aranda.Productos.Dominio.Dto
{
    public class FiltrosDto
    {
        public int RegistroActual { get; set; }
        public int CantidadRegistrosAConsultar { get; set; }
        public string TextoBuscar { get; set; }
        public int CodCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Orden { get; set; }
    }
    
}
