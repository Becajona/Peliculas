using Peliculas_aplication.Pelicula.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peliculas_aplication.Pelicula.ClienteWeb
{
    internal interface IPelicula
    {
        Task<List<pelicula>> ObtenerPeliculas();
        Task<pelicula> ObtenerPeliculas(int id);
        Task<List<string>> ObtenerGeneroPelicula();
        Task<List<pelicula>> ObtenerPeliculaPorGenero(string genero);
    }
}