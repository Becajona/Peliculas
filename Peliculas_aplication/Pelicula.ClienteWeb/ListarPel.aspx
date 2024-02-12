<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListarPel.aspx.cs" Inherits="Peliculas_aplication.Pelicula.ClienteWeb.ListarPel" async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="movieList" runat="server"
        GroupItemCount="3"
        ItemType="Peliculas_aplication.Pelicula.Entities.pelicula" SelectMethod="ObtenerPeliculas">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>Ningun dato fue devuelto</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyDataTemplate>
            </td>
        </EmptyDataTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td runat="server">
                <a href="#">
                    <img src="../Imagenes/<%#:Item.Imagen %>" width="105" height="125"
                     style="border:1px solid black" />
                </a>
                <br />
                <a href="#">
                    <span>
                        <%#:Item.Titulo %>
                    </span>
                </a>
                <br />
                <span>
                    <b>Formato: </b><%#:Item.Formato %>
                </span>
                <br />
                <span>
                    <b>Precio: </b><%#:string.Format("{0:c}", Item.Precio) %>
                </span>
                <br />
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table id ="groupPlaceholderContainer" runat="server" style="width:100%;"
                class="table table-striped table-responsive-sm table-responsive-md table-hover table-bordered">
                <tr id="groupPlaceholder">
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>



