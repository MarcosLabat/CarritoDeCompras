<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CarritoDeCompras.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" CssClass="h1 d-flex justify-content-center text-white" runat="server" Text=""></asp:Label>
    <div class="row row-cols-2 text-white mt-5">
        <%if (hayArt){%>
                <div class="col w-75 mx-auto">
            <div id="carouselExample" class="carousel slide">
                <div class="carousel-inner">
                    <% for (int i = 0; i < articulos[indice].Imagen.Count; i++){
                            if(i == 0){%>
                                <div class="carousel-item active">
                                   <img src="<%:articulos[indice].Imagen[i].ToString()%>" class="img-thumbnail mx-auto d-block w-75 mb-3" alt="prueba" />
                                 </div>
                            <%}else{%>
                                <div class="carousel-item">
                                   <img src="<%:articulos[indice].Imagen[i].ToString()%>" class="img-thumbnail mx-auto d-block w-75 mb-3" alt="prueba" />
                                 </div>
                              <%}%>
                    <% }%>
                </div>
                <%if (articulos[indice].Imagen.Count > 1){

%>
                      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                       </button>
                      <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                      </button>
                  <%}else{%>
                          <img src="https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg" class="img-thumbnail mx-auto d-block w-75 mb-3" alt="prueba" />
                    <%}%>
             </div>
        </div>
        <div class="col d-flex flex-column  align-items-center mx-auto">
            <asp:Label ID="tituloArticulo" CssClass="h2" runat="server" Text=""></asp:Label>
            <asp:Label ID="descArticulo" CssClass="h5" runat="server" Text=""></asp:Label>
            <asp:Label ID="marcaArticulo" CssClass="h5" runat="server" Text=""></asp:Label>
            <asp:Label ID="categoriaArticulo" CssClass="h5" runat="server" Text=""></asp:Label>
            <asp:Label ID="precioArticulo" CssClass="h5 fw-semibold text-success" runat="server" Text=""></asp:Label>
            <asp:Label ID="cuotasArticulo" CssClass="h6 fw-semibold text-primary " runat="server" Text=""></asp:Label>
            <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" />
        </div>    


         <%}%>
    </div>

</asp:Content>


