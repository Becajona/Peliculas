<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BuscarPorID.aspx.cs" Inherits="Peliculas_aplication.Pelicula.ClienteWeb.BuscarPorID" Async="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div class="card">
                    <div class="card-header bg-dark text-white">
                        <h4 class="mb-0">Búsqueda por ID</h4>
                    </div>
                    <div class="card-body">
                        <form runat="server" class="mb-4">
                            <div class="mb-3">
                                <label for="TextBox1" class="form-label">Escriba el ID</label>
                                <asp:TextBox ID="TexBox1" runat="server" CssClass="form-control" placeholder="ID de la película"></asp:TextBox>
                            </div>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" CssClass="btn btn-dark btn-block" />
                        </form>
                        <hr>
                        <div class="mb-3">
                            <label for="Label1" class="form-label">Título</label>
                            <asp:Label ID="Label1" runat="server" CssClass="form-control" Height="30"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="Label2" class="form-label">Género</label>
                            <asp:Label ID="Label2" runat="server" CssClass="form-control" Height="30"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="Label3" class="form-label">Formato</label>
                            <asp:Label ID="Label3" runat="server" CssClass="form-control" Height="30"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="Label4" class="form-label">Precio</label>
                            <asp:Label ID="Label4" runat="server" CssClass="form-control" Height="30"></asp:Label>
                        </div>
                         <asp:Image ID="Image1" runat="server" CssClass="img-fluid" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


