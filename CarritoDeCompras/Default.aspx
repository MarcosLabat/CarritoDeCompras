<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras._Default" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="mt-5 text-light text-center">
        <div class="mt-5"></div>

        <asp:Label ID="llbTitulo" CssClass="h3 d-flex justify-content-center text-white" runat="server" Text="PRODUCTOS"></asp:Label>
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card mw-100">
                            <div class="card-body">
                                <%# cargarImagen(((Dominio.Articulo)Container.DataItem)?.Imagen?.LastOrDefault()?.ToString()) %>
                                <asp:Image CssClass="card-img-top" ID="imgArticulo" runat="server" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'"/>
                                <h4 class="card-title"><%# ((Articulo)Container.DataItem).Nombre %></h4>
                                <p class="card-text"><%# ((Articulo)Container.DataItem).Descripcion %></p>
                                <p class="card-text fw-semibold text-success display-6">$<%# Math.Round(((Articulo)Container.DataItem).Precio, 2) %></p>
                                <a href="Detalle.aspx?id=<%# ((Articulo)Container.DataItem).Id %>" class="btn btn-primary w-100 mb-1">Ver más</a>
                                <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" OnClick="btnAgregar_Click" CommandArgument='<%# ((Articulo)Container.DataItem).Id.ToString() %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </main>

</asp:Content>
