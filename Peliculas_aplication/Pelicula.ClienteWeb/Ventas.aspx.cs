using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peliculas_aplication.CapaDAL;
using Peliculas_aplication.Interfaces;
using Peliculas_aplication.Pelicula.Entities;


namespace Peliculas_aplication.Pelicula.ClienteWeb
{
    public partial class Ventas : System.Web.UI.Page
    {
        IVentas Prod;
        pelicula producto;
        int Idprod;

        Venta venta;
        IAgregar Agregarventa;
        static double total;

        public Ventas()
        {
            Prod = new VentasDAL();
            producto = new pelicula();

            Agregarventa = new AgregaDAL();
            venta = new Venta();
        }

        protected void MuestraToast()
        {
            string csnamel = "Toast";
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;
            StringBuilder CadenaToast = new StringBuilder();

            CadenaToast.Append("<script type=text/javascript>");
            CadenaToast.Append("let myAlert = document.querySelector('.toast');");
            CadenaToast.Append("let bsAlert = new bootstrap.Toast(myAlert, {autohide: true,delay: 2000});");
            CadenaToast.Append("bsAlert.show();");
            CadenaToast.Append("</script>");

            cs.RegisterStartupScript(cstype, csnamel, CadenaToast.ToString());
        }

        protected void Mensaje(string notificacion)
        {
            string script = "document.getElementById(" + "'mensaje'" + ").innerHTML=" + notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);
        }


        protected void Modal(string nommodal)
        {
            string csnamel = "VentanaModal";
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            StringBuilder cstextl = new StringBuilder(); // Agregar System.Text

            cstextl.Append("<script type=text/javascript>");
            cstextl.Append(" const myModal = new bootstrap.Modal(" + nommodal + ", {keyboard: true, focus: true });");
            cstextl.Append(" myModal.show();");
            cstextl.Append("</script>");

            cs.RegisterStartupScript(cstype, csnamel, cstextl.ToString());
        }








        protected async void Page_Load(object sender, EventArgs e)
        {
            List<string> ProdId = new List<string>();
            Label2.Text = "Cantidad: ";

            Button2.Text = "Registrar_Venta";
            Button2.Enabled = false;

            if (!IsPostBack)
            {
               
                DropDownList1.AutoPostBack = true;

                Button1.Text = "Calcular";
                Label3.Text = "Total a Pagar: ";
                ProdId = await Prod.ObtenerProductoId();

                if (ProdId.Count > 0)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add("Selecciona Id");
                    for (int i = 0; i < ProdId.Count; ++i) // Se recorre la lista
                    {
                        DropDownList1.Items.Add(ProdId[i]);
                    }
                }
                else
                {
                    Mensaje("'No se devolvieron Ids de los productos'");
                    MuestraToast();
                }
            }

        }




        protected async void Button1_Click(object sender, EventArgs e)
        {
            int cantidad;
            Label3.Text = "";

            try
            {
                Idprod = Convert.ToInt16(DropDownList1.SelectedItem.ToString());
                producto = await Prod.ObtenerProducto(Idprod);
                cantidad = Convert.ToInt16(TextBox1.Text);

                if (cantidad < 0) throw new ArithmeticException();
                total = producto.Precio * cantidad;
                Label3.Text = "Total a Pagar: " + total.ToString();
            }
            catch (FormatException)
            {
                Mensaje("'Seleccione Id o capture cantidad'");
                MuestraToast();
            }
            catch (ArithmeticException)
            {
                Mensaje("'Cantidades deben ser positivas'");
                MuestraToast();
            }
            catch (Exception)
            {
                Mensaje("'Seleccione Id del producto'");
                MuestraToast();
            }
            MuestraToast();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string modal = "'#Pregunta'";
            Modal(modal);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", "mostrarModal();", true);
        }

        // Registro de la veenta

        protected async void Button3_Click(object sender, EventArgs e)
        {
            venta.ProductoId = Convert.ToInt16(DropDownList1.SelectedItem.ToString());
            venta.Cantidad = Convert.ToInt16(TextBox1.Text);
            venta.TotalVenta = total;
            venta.Fecha = DateTime.Now;

            if (await Agregarventa.RegistrarVenta(venta)) 
            {
                Mensaje("'La Venta Se Registró Satisfactoriamente'");
                MuestraToast();
            }
            else
            {
                Mensaje("'Ocurrió un Error al Registrar la Venta'");
                MuestraToast();
            }
          
            Mensaje("Se ha confirmado la venta");
            MuestraToast();

            // Cerrar la ventana modal después de confirmar la venta
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarModal", "$('#Pregunta').modal('hide');", true);
        }

        protected async void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                Idprod = Convert.ToInt16(DropDownList1.SelectedItem.ToString());

                if (Idprod < 0) throw new Exception();


                producto = await Prod.ObtenerProducto(Idprod);

                if (producto != null) Label1.Text = "Descripción:" + producto.Titulo + " " + producto.Genero;

                else
                {
                    Mensaje("'No se encontraron coincidencias'");
                    MuestraToast();
                }
            }
            catch (Exception x)
            {
                Mensaje("'" + x.Message + "'");
                MuestraToast();
            }
        }
    }
}
