using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peliculas_aplication.Pelicula.Entities
{
    public class pelicula
    {
        public int ID_Pelicula { set; get; }
        public string Titulo { set; get; }
        public string Formato { set; get; }
        public string Genero { set; get; }
        public int Existencia { set; get; }
        public double Precio { set; get; }
        public string Imagen { set; get; }
    }
}