using Peliculas_aplication.Pelicula.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas_aplication.Interfaces
{
    internal interface IAgregar
    {
        Task<bool> RegistrarVenta(Venta Vnta);
    }
}
