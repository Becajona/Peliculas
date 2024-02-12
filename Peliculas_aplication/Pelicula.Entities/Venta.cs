using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peliculas_aplication.Pelicula.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double TotalVenta { get; set; }
        public DateTime Fecha { get; set; }
    }
}