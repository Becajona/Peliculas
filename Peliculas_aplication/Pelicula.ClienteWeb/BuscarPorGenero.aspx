<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BuscarPorGenero.aspx.cs" Inherits="Peliculas_aplication.Pelicula.ClienteWeb.BuscarPorGenero" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <br />
        <div class="d-flex justify-content-center align-items-center mb-3">
            <p id="busqueda">Búsqueda Por Categoria</p>
        </div>

        <div class="mb-0">
            <label id="bid" class="form-label" for="TextBox1">Seleccione Categoria</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <br />
        <hr />
        <div class="d-flex justify-content-center align-items-center">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="false"
                CssClass="table table-responsive table-warning table-hover"
                HeaderStyle-BackColor="#ffe28a" 
                GridLines="Vertical" 
                Font-Size="Small"
                HeaderStyle-Font-Size="Medium">
            </asp:GridView>
        </div>
    </form>
</asp:Content>

