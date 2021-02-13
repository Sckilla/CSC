<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflDescProdC.aspx.cs" Inherits="dflDescProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#ffffff">
        <div class="TituloPaginaN" style="text-align:center; font-weight:100;">
        DESCRIPCIÓN

        <br />

        </div>
        <table style="width:70%; text-align: center; margin:0 auto">
            <tr>
                <td style="width:30%">

                    <div style="width:300px; height:300px; margin:0 auto">
                        <asp:Image ID="imgFotoProd" runat="server" Height="100%" Width="100%" />
                    </div>

                </td>
                <td>
                    <div class="Descripcion">

                        <asp:Label ID="lblArticulo" runat="server" CssClass="TituloProd"></asp:Label>

                        <br />
                        <br />
                        Descripción:&nbsp;
                        <asp:Label ID="lblDescripción" runat="server" CssClass="IndicacionN"></asp:Label>
                        <br />
                        <br />

                        Existencias:&nbsp;
                        <asp:Label ID="lblExistencias" runat="server" CssClass="IndicacionN"></asp:Label>
                        
                        <br />
                        <br />
                        <asp:Label ID="lblPrecioSD" runat="server" CssClass="PrecioR"></asp:Label>
                        <br />
                        &nbsp;<asp:Label ID="lblPrecio" runat="server" CssClass="PrecioG"></asp:Label>

                        <br />

                        <br /> 

                        <asp:Label ID="lblIdet" runat="server" Text="0" Visible="False"></asp:Label>

                        <br />

                    </div>
                        <table style="text-align: center; margin:0 auto; height:60px; width:200px">
                            <tr>
                                <td class="Descripcion" style="font-size:15px">
                                    Agregar al Carrito
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="dwlCant" runat="server" Width="50px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbAddCart" runat="server" Height="50px" ImageUrl="~/Imagenes/addcart.png" Width="50px" OnClick="imgbAddCart_Click" />

                                </td>
                            </tr>
                        </table>
                </td>
            </tr>
        </table>
        <br />

    </div>
</asp:Content>

