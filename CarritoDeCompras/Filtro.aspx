<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filtro.aspx.cs" Inherits="CarritoDeCompras.Filtro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" CssClass="h3 d-flex justify-content-center text-white mb-3 text-center" runat="server" Text=""></asp:Label>
    <%if(listaArticulo != null && listaArticulo.Count > 0){%>
      <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <% foreach (var item in listaArticulo){
%>
                <div class="col">
                        <div class="card mw-100">
                            <div class="card-body">
                                <%if (item.Imagen == null || item.Imagen.Count == 0){
                                        cargarImagen("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
                                  }else{
                                        cargarImagen(item.Imagen.First().ToString());
                                   }%>
                                <asp:Image  CssClass="card-img-top" ID="imgArticulo" runat="server" />
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
    <%}%>
</asp:Content>
