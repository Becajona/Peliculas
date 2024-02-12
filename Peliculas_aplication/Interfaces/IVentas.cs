using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peliculas_aplication.Pelicula.Entities;

namespace Peliculas_aplication.Interfaces
{
    internal interface IVentas
    {
        Task<pelicula> ObtenerProducto(int id);
        Task<List<string>> ObtenerProductoId();
    }
}
