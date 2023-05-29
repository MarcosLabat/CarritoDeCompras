<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="CarritoDeCompras.Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    body {
        color: white;
    }

    table, th, td {
        color: white;
    }
</style>

<h1>Página de Pago</h1>
    <table class="table">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Precio</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptCarrito" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Precio", "{0:C}") %></td>
                        <td><asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Container.ItemIndex %>' OnClick="btnEliminar_Click" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>Total:</td>
                <td colspan="2"><%: ObtenerTotalCarrito().ToString() %></td>
            </tr>
        </tbody>
    </table>
    <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary" OnClick="btnPagar_Click" />
</asp:Content>
