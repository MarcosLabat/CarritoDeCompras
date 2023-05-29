<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="mt-5 text-light text-center">
        <div class="mt-5"></div>

        <asp:Label ID="llbTitulo" CssClass="h3 d-flex justify-content-center text-white" runat="server" Text="PRODUCTOS"></asp:Label>
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <% foreach (var item in ListaArticulos)
                { %>
            <div class="col">
                <div class="card mw-100">
                    <div class="card-body">
                        <% if (item.Imagen.Count > 0)
                            {
                                cargarImagen(item.Imagen.First().ToString());
                            }
                            else
                            {
                                cargarImagen("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
                            }
                        %>
                        <asp:Image CssClass="card-img-top" ID="imgArticulo" runat="server" />
                        <h4 class="card-title"><%: item.Nombre%></h4>
                        <p class="card-text"><%:item.Descripcion %></p>
                        <p class="card-text fw-semibold text-success"><%: item.Precio + "$"%></p>
                        <a href="Detalle.aspx?id=<%:item.Id %>" class="btn btn-primary w-100 mb-1">Ver más</a>
                        <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" OnClick="btnAgregar_Click" CommandArgument="1" />
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </main>

</asp:Content>
