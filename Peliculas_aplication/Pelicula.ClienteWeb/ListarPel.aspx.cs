using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peliculas_aplication.Pelicula.Entities;
using Peliculas_aplication.CapaDAL;



namespace Peliculas_aplication.Pelicula.ClienteWeb
{
    public partial class ListarPel : Page
    {
        IPelicula PeliculaDAL;

        public ListarPel()
        {
            PeliculaDAL = new PeliculaDAL(); 
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    await ObtenerPeliculas();
            //}
        }

        public async Task<List<pelicula>> ObtenerPeliculas()
        {
            List<pelicula> ListPeliculas = new List<pelicula>();

            ListPeliculas = await PeliculaDAL.ObtenerPeliculas();
            if (ListPeliculas == null)
            {
                Mensaje("'No se devolvieron registros'");
                MuestraToast();
                return null;
            }
            return ListPeliculas;
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
    }
}