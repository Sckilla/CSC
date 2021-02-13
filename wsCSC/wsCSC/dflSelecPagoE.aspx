<%@ Page Title="" Language="C#" MasterPageFile="~/mpEmpleado.master" AutoEventWireup="true" CodeFile="dflSelecPagoE.aspx.cs" Inherits="dflSelecPagoE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#ffffff">
    <div style="text-align:center" class="TituloPaginaN">
        Selecciona tu método de pago
    </div>
    <table style="text-align: center; width:60%; margin:0 auto" class="Tablas">
        <tr>
            <td style="width:33%">
                Tarjeta
            </td>
            <td style="width:34%">
                Transferencia
            </td>
            <td style="width:33%">
                Depósito
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="imgbTar" runat="server" Width="100px" ImageUrl="~/Imagenes/TARJETA.png" OnClick="imgbTar_Click" />
            </td>
            <td>
                <asp:ImageButton ID="imgbTra" runat="server" ImageUrl="~/Imagenes/TRANSFERENCIA.png" Width="100px" OnClick="imgbTra_Click" />
            </td>
            <td>
                <asp:ImageButton ID="imgbDep" runat="server" ImageUrl="~/Imagenes/DEPOSITO.png" Width="100px" OnClick="imgbDep_Click" />
            </td>
        </tr>
    </table>
    <div>
        <table style="text-align:left; width:60%; margin:0 auto" class="Tablas">
            <tr>
                <td style="width:50%">

                    <asp:Label ID="lblTarjetaNom" runat="server" Text="Tarjeta bancaria" Visible="False"></asp:Label>
                    <br />
                    <asp:DropDownList ID="dwlNTarjeta" runat="server" Width="75%" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="dwlNTarjeta_SelectedIndexChanged" CssClass="txt">
                    </asp:DropDownList>
                </td>
                <td>

                    <asp:Label ID="lblMet" runat="server" Text="0" Visible="False"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="lblCve" runat="server" Text="Numero" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNumero" runat="server" Width="75%" MaxLength="16" Visible="False" CssClass="txt"></asp:TextBox>

                    <br />
                    <asp:RegularExpressionValidator ID="revNumero" runat="server" CssClass="Link" ErrorMessage="Numero incorrecto ####" ControlToValidate="txtNumero"></asp:RegularExpressionValidator>

                </td>
                <td>

                    <asp:Label ID="lblFecha" runat="server" Text="Fecha" Visible="False"></asp:Label>


                    <br />
                    <asp:DropDownList ID="dwlDia" runat="server" Visible="False" Width="20%" CssClass="txt">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:DropDownList ID="dwlMes" runat="server" Visible="False" Width="20%" OnSelectedIndexChanged="dwlMes_SelectedIndexChanged" AutoPostBack="True" CssClass="txt">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:DropDownList ID="dwlAño" runat="server" Visible="False" Width="20%" AutoPostBack="True" OnSelectedIndexChanged="dwlAño_SelectedIndexChanged" CssClass="txt">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="txtCveTj" runat="server" Visible="False" Width="20%" MaxLength="4" CssClass="txt"></asp:TextBox>


                    <br />
                    <asp:RegularExpressionValidator ID="revCve" runat="server" CssClass="Link" ErrorMessage="Clave incorrecta ###[#]" ControlToValidate="txtCveTj" ValidationExpression="[0-9]{3,4}"></asp:RegularExpressionValidator>


                </td>
            </tr>
            </table>
        <div style="margin:0 auto; text-align: center">

            <br />
            <asp:ImageButton ID="imgbContinuar" runat="server" ImageUrl="~/Imagenes/Continuar.png" OnClick="imgbContinuar_Click" Width="10%" Visible="False" />
            <br />

            <br />
        </div>
    </div>
    </div>
</asp:Content>

