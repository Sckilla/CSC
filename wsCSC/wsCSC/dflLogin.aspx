<%@ Page Title="" Language="C#" MasterPageFile="~/mpGeneral.master" AutoEventWireup="true" CodeFile="dflLogin.aspx.cs" Inherits="dflLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="background-color:#000">
        <div>

            <br />

        </div>
        <div style="margin: 0 35%; background:#000;">
        <h1 style="margin: 0 auto; text-align:center; width:300px" class="TituloPaginaB">
            LOGIN
        </h1>
        <table style="margin: 0 auto; text-align:center; width:300px;" class="IndiCampos">
            <tr>
                <td style="text-align:left; color:#ffffff" >
                    Usuario:
                </td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; color:#ffffff">
                    Contraseña:
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPassw" runat="server" BackColor="White" TextMode="Password" OnTextChanged="txtPassw_TextChanged" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                         
                    <asp:ImageButton ID="imgbLogin" runat="server" src="Imagenes/loginsc.png" Height="50px" Width="50px" OnClick="imgbLogin_Click"/>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">

                    <a class="boton" style="color:#ffffff" href="dflRegistroC.aspx">Regístrate como nuevo cliente</a>

                </td>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>

