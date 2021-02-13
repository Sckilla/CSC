<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflCarritoC.aspx.cs" Inherits="dflCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN" style="font-weight:bold">
        CARRITO DE COMPRAS
        </div>
    <div style="text-align:center; color: #000; font-family:'Tw Cen MT'; font-size: 22px; font-weight: bold;">
        Compras añadidas:
        <asp:Label ID="lblArtAd" runat="server" />
    </div>

    <table style="border:0; width:90%; text-align: center; margin: 0 auto">
        <tr>
            <td>
                <asp:GridView ID="gvCarrito" runat="server" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" OnRowDeleting="gvCarritoC_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas" Width="100%" OnSelectedIndexChanging="gvCarrito_SelectedIndexChanging">
            <Columns>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/delt.png" ShowDeleteButton="True">
                <ControlStyle Height="27px" Width="27px" />
                </asp:CommandField>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="PRODUCTO" HeaderText="Artículos" />
                <asp:ImageField DataAlternateTextField="FOTO" DataAlternateTextFormatString="FOTO" DataImageUrlField="FOTO">
                    <ControlStyle Height="35px" Width="35px" />
                </asp:ImageField>
                <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                <asp:BoundField DataField="PRECIO" HeaderText="Precio Unit" DataFormatString="{0:C}" />
                <asp:BoundField DataField="SUBTOTAL" DataFormatString="{0:C}" HeaderText="Subtotal" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/img_27222.png" ShowSelectButton="True">
                <ControlStyle Height="25px" Width="25px" />
                <ItemStyle Height="25px" Width="25px" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
            </td>

            <td>

                &nbsp;&nbsp; &nbsp;

            </td>
            <td>
                <table class="IndiCampos" style="color:#000; border:0; width:100%; text-align: center;">
                    <tr class="Info">
                        <td style="text-align: center; background-color: #920000; color: #ffffff" colspan="2">
                            RESUMEN
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Productos
                        </td>
                        <td>
                            <asp:Label ID="lblCantP" runat="server" CssClass="InfoLow"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Envío:
                        </td>
                        <td>          
                            <div>
                                <asp:Label ID="lblEnvío" runat="server" Text="Por definir"></asp:Label>
                                <asp:ImageButton ID="imgbAddEnv" runat="server" src="Imagenes/img_27222.png" Width="20px" Height="20px" OnClick="imgbAdEnvio_Click"/>
                            </div>
                            <div>
                                <asp:Label ID="lblCostoEnv" runat="server"></asp:Label>
                            </div>                 
                        </td>
                    </tr>
                    <tr>
                        <td class="Info" style="background-color: #920000; color: #ffffff">
                            Subtotal
                        </td>
                        <td>

                            <asp:Label ID="lblSubtotal" runat="server" CssClass="InfoLow"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td class="Info" style="background-color: #920000; color: #ffffff">
                            Iva
                        </td>
                        <td>

                            <asp:Label ID="lblImp" runat="server" CssClass="InfoLow"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td class="Info" style="background-color: #920000; color: #ffffff">
                            Total
                        </td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;<asp:ImageButton ID="imgbPagar" runat="server" Height="30px" ImageUrl="~/Imagenes/Comprar.png" OnClick="imgbPagar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <div>
        <br />
        <br />
        <div style="margin:0 auto; width:170px">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff" href="dflCatalogoGralC.aspx">Ver más productos</a>
        </div>
        <br />
    </div>
    </div>
    

</asp:Content>

