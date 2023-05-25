<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="mt-5 text-light text-center">
        <div class="mt-5"></div>

        <asp:Label ID="llbTitulo" CssClass="fs-3" runat="server" Text="PRODUCTOS"></asp:Label>
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <asp:Repeater ID="repArticulos" runat="server">
                <ItemTemplate>

                    <div class="col">
                        <div class="card mw-100">
                            <div class="card-body">
                                <img src="<%#Eval("Imagen[0]") %>" class="card-img-top" alt="<%#Eval("Nombre") %>" />
                                <h4 class="card-title"><%#Eval("Nombre") %></h4>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <p class="card-text fw-semibold text-success"><%#Eval("Precio") %></p>
                                <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="btn btn-primary w-100 mb-1">Ver más</a>
                                <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" />
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </main>

</asp:Content>
