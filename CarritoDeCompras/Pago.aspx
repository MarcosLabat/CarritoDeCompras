<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="CarritoDeCompras.Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .pago table, .pago h1 {
        color: white;
    }
</style>
    <div class="pago">
        <h1>Página de Pago</h1>
        <table class="table">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Descripcion</th>
                    <th>Precio</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptCarrito" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Descripcion") %></td>
                            <td><%# Eval("Precio", "{0:C}") %></td>
                            <td>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Container.ItemIndex %>' OnClick="btnEliminar_Click" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="display-6">Total</td>
                    <td></td>
                    <td colspan="2" class="display-6"><%: ObtenerTotalCarrito().ToString() %></td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary" OnClick="btnPagar_Click" />
</asp:Content>
