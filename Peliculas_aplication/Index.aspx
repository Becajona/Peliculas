<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Peliculas_aplication.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 class="display-4">Sitio Web de Películas</h1>
        <p class="lead">Selección de películas para todos los gustos.</p>
        <hr class="my-4">
        <p>Explora las categorías y descubre tus películas favoritas.</p>
        <a class="btn btn-primary btn-lg" href="#" role="button">Ver películas</a>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Categorías</h2>
            <p>Explora las categorías de películas para encontrar lo que estás buscando.</p>
            <p><a class="btn btn-secondary" href="#" role="button">Ver más &raquo;</a></p>
        </div>
        <div class="col-md-4">
            <h2>Lo más popular</h2>
            <p>Descubre las películas más populares que están siendo vistas por nuestra comunidad.</p>
            <p><a class="btn btn-secondary" href="#" role="button">Ver más &raquo;</a></p>
        </div>
        <div class="col-md-4">
            <h2>Ofertas</h2>
            <p>No te pierdas nuestras ofertas especiales en una selección de películas.</p>
            <p><a class="btn btn-secondary" href="#" role="button">Ver más &raquo;</a></p>
        </div>
    </div>
</asp:Content>

