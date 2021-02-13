<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflMenuVentasC.aspx.cs" Inherits="dflMenuVentasC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN">
            MIS COMPRAS
        </div>
        <br />

        <div class="Info" style="text-align: left; width:85%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:200px; text-align: center" href="dflComprasC.aspx">Administrar</a>&nbsp;&nbsp;&nbsp;
            Selecciona, cancela o visualiza los detalles de venta de una compra específica
            <br />
            <br />
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:200px; text-align: center" href="dflRepVentasTotC.aspx">Ventas generales</a>&nbsp;&nbsp;&nbsp;
            Visualiza todas las ventas realizadas, separadas las activas de las canceladas
            <br />
            <br />
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:200px; text-align: center" href="dflRepVentasCanC.aspx">Ventas canceladas</a>&nbsp;&nbsp;&nbsp;
            Visualiza las ventas canceladas
            <br />
            <br />
        </div>
        <div style="text-align: center">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:100px; text-align: center" href="dflInicioC.aspx">Inicio</a>
            <br />
        </div>
    </div>
</asp:Content>

