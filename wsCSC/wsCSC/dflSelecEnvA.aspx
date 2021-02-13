<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdministrador.master" AutoEventWireup="true" CodeFile="dflSelecEnvA.aspx.cs" Inherits="dflSelecEnvA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#ffffff">
        <div style="text-align:center;" class="TituloPaginaN">
            Selecciona un medio de envío
        </div>
        <div style="width:60%; margin:0 auto">
            <asp:ImageButton ID="imgbFedEx" runat="server" ImageUrl="~/Imagenes/fedex.png" OnClick="imgbFedEx_Click" Width="30%" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgbDHL" runat="server" ImageUrl="~/Imagenes/dhl.png" OnClick="imgbDHL_Click" Width="30%" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgbEstafeta" runat="server" ImageUrl="~/Imagenes/estafeta.png" OnClick="imgbEstafeta_Click" Width="30%" />
        </div> 
    </div>
</asp:Content>

