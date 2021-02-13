<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflDetalleVentaC.aspx.cs" Inherits="dflDetalleVentaC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#ffffff; text-align:center">
        <div class="TituloPaginaN">
        Dettalles de la venta
        </div>
        <div>
            <table style="width:50%; margin:0 auto; text-align: center" class="IndiCamposN">
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:TextBox ID="txtCliente" runat="server" Width="100%" CssClass="txt" Enabled="False"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblDir" runat="server" Text="Dirección de envío"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:TextBox ID="txtDir" runat="server" Width="100%" CssClass="txt"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblEnvío" runat="server" Text="Método de envío"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:TextBox ID="txtEnvío" runat="server" Width="90%" CssClass="txt" Enabled="False"></asp:TextBox>

                        <asp:ImageButton ID="imgbMetEnv" runat="server" Width="10%" OnClick="imgbMetEnv_Click" />

                    </td>
                </tr>
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblPago" runat="server" Text="Método de pago"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:TextBox ID="txtPago" runat="server" Width="100%" CssClass="txt" Enabled="False"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:TextBox ID="txtSubtotal" runat="server" Width="100%" CssClass="txt" Enabled="False"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblImp" runat="server" Text="Impuestos"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:TextBox ID="txtImpuestos" runat="server" Width="100%" CssClass="txt" Enabled="False"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width:35%">

                        <asp:Label ID="lblTotalAP" runat="server" Text="Total a pagar"></asp:Label>

                    </td>
                    <td style="width:65%">

                        <asp:Label ID="lblTotal" runat="server" CssClass="PrecioG" Text="TOTAL"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>
        <div>

            <asp:ImageButton ID="imgbConfirmarC" runat="server" ImageUrl="~/Imagenes/ConfCompra.png" OnClick="imgbConfirmarC_Click" Width="12%" />
            <br />

        </div>
    </div>
    
</asp:Content>

