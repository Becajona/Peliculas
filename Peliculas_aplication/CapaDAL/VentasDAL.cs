using Peliculas_aplication.Interfaces;
using Peliculas_aplication.Pelicula.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Peliculas_aplication.CapaDAL
{
    public class VentasDAL : IVentas
    {
        string dbconexion;

        public VentasDAL()
        {
            dbconexion = ConfigurationManager.ConnectionStrings["ConectaPeliculas"].ConnectionString;
        }


        public async Task<List<string>> ObtenerProductoId()
        {
            List<string> ProductoId = new List<string>();

            using (SqlConnection con = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPeliculaID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ProductoId.Add(sdr["ID_Pelicula"].ToString());
                        }
                        con.Close();
                    }
                    else
                    {
                        ProductoId = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return (ProductoId);
        }

        public async Task<pelicula> ObtenerProducto(int id)
        {
            pelicula Pr = new pelicula();
            using (SqlConnection con = new SqlConnection(dbconexion))
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
                            Pr.Titulo = sdr["Titulo"].ToString();
                            Pr.Genero = sdr["Genero"].ToString();
                            Pr.Formato = sdr["Formato"].ToString();
                            Pr.Precio = Convert.ToDouble(sdr["Precio"]);
                            
                        }
                        con.Close();
                    }
                    else
                    {
                        Pr = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return (Pr);
            }
        }
    }
}