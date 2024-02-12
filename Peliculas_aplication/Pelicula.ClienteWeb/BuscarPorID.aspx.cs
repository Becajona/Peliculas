using Peliculas_aplication.CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peliculas_aplication.Pelicula.Entities;

namespace Peliculas_aplication.Pelicula.ClienteWeb
{
    public partial class BuscarPorID : System.Web.UI.Page
    {
        IPelicula Prod;
        public BuscarPorID()
        {
            Prod = new PeliculaDAL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Buscar";
        }
       



        protected void MuestraToast()
        {
            string csname1 = "Toast";
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;
            StringBuilder CadenaToast = new StringBuilder();

            CadenaToast.Append("<script type=text/javascript>");
            CadenaToast.Append("let myAlert = document.querySelector('.toast');");
            CadenaToast.Append("let bsAlert = new bootstrap.Toast(myAlert,{autohide: true, delay: 2000});");
            CadenaToast.Append("bsAlert.show();");
            CadenaToast.Append("</script>");

            cs.RegisterStartupScript(cstype, csname1, CadenaToast.ToString());
        }

        protected void Mensaje(string notificacion)
        {
            string script = "document.getElementById(" + "'mensaje'" + ").innerHTML=" + notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            int Idprod;

            pelicula producto = new pelicula();

            try
            {
                if (string.IsNullOrEmpty(TexBox1.Text))
                {
                    Mensaje("'Capture un ID válido'");
                    MuestraToast();
                    return; // Salir del método si la caja de texto está vacía
                }

                Idprod = Convert.ToInt16(TexBox1.Text);
                if (Idprod < 0) throw new Exception();

                producto = await Prod.ObtenerPeliculas(Idprod);

                if (producto != null)
                {
                    Label1.Text = producto.Titulo;
                    Label2.Text = producto.Genero;
                    Label3.Text = producto.Formato;
                    Label4.Text = producto.Precio.ToString();

                    // Construir la URL completa de la imagen
                    string imagenUrl = ResolveUrl("~/Imagenes/" + producto.Imagen);

                    // Asignar la URL de la imagen al control Image
                    Image1.ImageUrl = imagenUrl;

                }
                else
                {
                    Mensaje("'No se encontraron coincidencias'");
                    MuestraToast();
                }
            }
            catch (FormatException)
            {
                Mensaje("'Capture Ids válidos'");
                MuestraToast();
            }
            catch (Exception)
            {
                Mensaje("'Capture Ids positivos'");
                MuestraToast();
            }

        }
    }
}