using Peliculas_aplication.CapaDAL;
using Peliculas_aplication.Pelicula.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peliculas_aplication.Pelicula.ClienteWeb
{
    public partial class BuscarPorGenero : System.Web.UI.Page
    {

            IPelicula ListGenero;
            public BuscarPorGenero()
            {
            ListGenero = new PeliculaDAL();
            }

            protected void MuestraToast()
            {
                string csname1 = "Toast";
                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;
                StringBuilder CadenaToast = new StringBuilder();

                CadenaToast.Append("<script type=text/javascript>");
                CadenaToast.Append("let myAlert = document.querySelector('.toast');");
                CadenaToast.Append("let bsAlert = new bootstrap.Toast(myAlert,{autohide: true,delay: 2000});");
                CadenaToast.Append("bsAlert.show();");
                CadenaToast.Append("</script>");

                cs.RegisterStartupScript(cstype, csname1, CadenaToast.ToString());
            }

            protected void Mensaje(string notificacion)
            {
                string script = "document.getElementById(" + "'mensajes'" + ").innerHTML = " + notificacion + ";";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);
            }

            // Se contruyen las columnas del control GridView a visualizar

            protected void GeneraColumnasGrid()
            {
                BoundField colum = new BoundField();
                colum = new BoundField // se agrega la columna al gridview
                {
                    HeaderText = "Titulo",
                    DataField = "Titulo"
                };
                GridView1.Columns.Add(colum); // Se agrega la columna al gridview

                colum = new BoundField(); //Se crea una nueva instancia
                colum.HeaderText = "Formato";
                colum.DataField = "Formato";
                GridView1.Columns.Add(colum);

                colum = new BoundField();
                colum.HeaderText = "Genero";
                colum.DataField = "Genero";
                GridView1.Columns.Add(colum);

                colum = new BoundField();
                colum.HeaderText = "Precio";
                colum.DataField = "Precio";
                GridView1.Columns.Add(colum);

                colum = new BoundField();
                colum.HeaderText = "Existencia";
                colum.DataField = "Existencia";
                GridView1.Columns.Add(colum);
               
            }

            protected async void Page_Load(object sender, EventArgs e)
            {
                List<string> GeneroPelicul = new List<string>();

                if (!IsPostBack) // Al cargar por primera vez la página (se realizo un postback)
                {
                    DropDownList1.AutoPostBack = true; // Se habilita el postback del dropdownlist, esto es, para que cuando
                                                       // el usuario seleccione un producto del dropdown se ejecute el evento
                                                       // selectedIndexChanged del dropdown
                GeneroPelicul = await ListGenero.ObtenerGeneroPelicula(); // Se cunsulta la BD,
                    if (GeneroPelicul.Count > 0) // si hay nombres de productos
                    {
                        DropDownList1.Items.Clear(); // se vacia el control dropdown
                        DropDownList1.Items.Add("Selecciona Categoria");

                        for (int i = 0; i < GeneroPelicul.Count; ++i) // Se recorre la lista
                        {
                            // Se extraen los nombres de los productos elemento por elemento
                            DropDownList1.Items.Add(GeneroPelicul[i]); // Se hace el llenado con los nombre de los Producto
                                                                    // en el dropdown
                        }
                    }
                    else
                    {
                        Mensaje("'No se devolvieron categoria de los productos'");
                        MuestraToast();
                    }
                }
            }

            protected async void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                string Genero;

                List<pelicula> ListProductos = new List<pelicula>();


            Genero = DropDownList1.SelectedItem.ToString(); // Seleccionamos un elemento del drodownlist;
                ListProductos = await ListGenero.ObtenerPeliculaPorGenero(Genero);
                if (ListProductos != null)
                {
                    GeneraColumnasGrid();
                    GridView1.DataSource = ListProductos;
                    GridView1.DataBind();
                    GridView1.Columns.Clear();
                }
                else
                {
                    Mensaje("'No se encontraron coincidencias'");
                    MuestraToast();
                }
            }
    }
}