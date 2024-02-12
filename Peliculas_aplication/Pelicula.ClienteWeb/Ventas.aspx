<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Peliculas_aplication.Pelicula.ClienteWeb.Ventas" Async="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <div class="d-flex justify-content-center align-items-center mb-3">
    <p id="busqueda">Venta de un Producto</p>
</div>

<div class="mb-2">
    <label id="bid" class="form-label" for="TextBox1">Seleccione Id del Producto</label>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1"></asp:DropDownList>

</div>

<div class="mb-0">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>

<br />
<hr />

<div class="container">
    <div class="row border mb-2">
        <div class="col-sm-12 col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="50"></asp:TextBox>
        </div>
    </div>
    <div class="row border border-warning mt-2">
        <div class="col-sm-12 col-md-12">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>
    </div>

    <div class="row mt-2">
        <div class="col-sm-12 col-md-12">
            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn-outline-warning" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn-outline-warning" OnClick="Button2_Click" />

        </div>
    </div>
</div>
       

    <%-- Ventana Modal --%>

</form>
</asp:Content>





