using Peliculas_aplication.Pelicula.ClienteWeb;
using Peliculas_aplication.Pelicula.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Peliculas_aplication.CapaDAL
{
    public class PeliculaDAL : IPelicula
    {
        string conexbd;
        public PeliculaDAL()
        {
            conexbd = ConfigurationManager.ConnectionStrings["ConectaPeliculas"].ConnectionString; // Corregir el acceso a la cadena de conexión
        }
        public async Task<List<pelicula>> ObtenerPeliculas()
        {
            List<pelicula> ListPeliculas = new List<pelicula>();
            using (SqlConnection con = new SqlConnection(conexbd))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPeliculas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListPeliculas.Add(new pelicula
                            {
                                Titulo = sdr["Titulo"].ToString(),
                                Formato = sdr["Formato"].ToString(),
                                Precio = Convert.ToDouble(sdr["Precio"]),
                                Imagen = sdr["Imagen"].ToString(),
                            });
                        }
                        con.Close();
                    }
                    else
                    {
                        ListPeliculas = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return (ListPeliculas);
            }

        }

        public async Task<pelicula> ObtenerPeliculas(int id)
        {
            pelicula obj = new pelicula();
            using (SqlConnection con = new SqlConnection(conexbd))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPeliculas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pelicula", id);

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            obj.ID_Pelicula = Convert.ToInt16(sdr["ID_Pelicula"]);
                            obj.Titulo = sdr["Titulo"].ToString();
                            obj.Genero = sdr["Genero"].ToString();
                            obj.Formato = sdr["Formato"].ToString();
                            obj.Precio = Convert.ToDouble(sdr["Precio"]);
                            obj.Imagen = sdr["Imagen"].ToString();

                        }
                        con.Close();
                    }
                    else
                    {
                        obj = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return obj;

            }
        }



        public async Task<List<string>> ObtenerGeneroPelicula()
        {
            List<string> NombreProducto = new List<string>();
            using (SqlConnection con = new SqlConnection(conexbd))
            {
                SqlCommand cmd = new SqlCommand("GeneroPelicula", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            NombreProducto.Add(sdr["Genero"].ToString());
                        }
                        con.Close();
                    }
                    else
                    {
                        NombreProducto = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return (NombreProducto);
        }
        public async Task<List<pelicula>> ObtenerPeliculaPorGenero(string nombre)
        {
            List<pelicula> ListProductos = new List<pelicula>();

            using (SqlConnection con = new SqlConnection(conexbd))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPeliculaPorGenero", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GeneroPelicula", nombre);

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListProductos.Add(new pelicula
                            {
                                Titulo = sdr["Titulo"].ToString(),
                                Formato = sdr["Formato"].ToString(),
                                Genero = sdr["Genero"].ToString(),
                                Precio = Convert.ToDouble(sdr["Precio"]),
                                Existencia = Convert.ToInt16(sdr["Existencia"]),
                                
                            });
                        }
                        con.Close();
                    }
                    else
                    {
                        ListProductos = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return (ListProductos);
            }
        }
    }
}