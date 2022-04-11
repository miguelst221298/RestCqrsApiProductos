using System;
using System.Collections.Generic;
using System.Text;

namespace Aranda.Productos.Dominio.Dto
{
    public class FiltrosDto
    {
        public int CodCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Orden { get; set; }
    }
    public class PaginacionDto
    {
        public int Pagina { get; set; } = 1;
        private int RegistrosPorPagina = 10;
        private readonly int _cantidadMaximaPorPagina = 50;
        public int CantidadRegistrosAConsultar
        {
            get
            {
                return RegistrosPorPagina;
            }
            set
            {
                RegistrosPorPagina = (value > _cantidadMaximaPorPagina) ? _cantidadMaximaPorPagina : value;
            }


        }

    }

}