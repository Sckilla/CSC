<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdministrador.master" AutoEventWireup="true" CodeFile="dflMenuRep.aspx.cs" Inherits="dflMenuRep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN">
            REPORTES
        </div>
        <br />
        <div class="Info" style="text-align:left; width:75%; margin: 0 auto">
            VENTAS
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteVentasRec.aspx">Ventas recientes</a>&nbsp;&nbsp;&nbsp;
            Genara un reporte de las últimas 20 ventas realizadas
            <br />
            <br />
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteTotalVentas.aspx">Total de ventas</a>&nbsp;&nbsp;&nbsp;
            Genara un reporte de todas las ventas realizadas
            <br />
            <br />
        </div>
        <br />
        <div class="Info" style="text-align:left; width:75%; margin: 0 auto">
            PRODUCTOS
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteProdMasV.aspx">Más vendidos</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de los 10 productos más vendidos
            <br />
            <br />
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteProdMenV.aspx">Menos vendidos</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de los 10 productos menos vendidos
            <br />
            <br />
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteProdCE.aspx">Con existencias</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de los productos activos con existencias
            <br />
            <br />
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteProdSE.aspx">Sin existencias</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de los productos activos sin existencias
            <br />
            <br />
        </div>
        <br />
        <div class="Info" style="text-align:left; width:75%; margin: 0 auto">
            USUARIOS
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteVentasXCli.aspx">Compras realizadas</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de las compras realizadas por un cliente
            <br />
            <br />
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteCliReg.aspx">Clientes Registrados</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de los clientes registrados activos
            <br />
            <br />
        </div>
        <div class="Info" style="text-align: left; width:75%; margin: 0 auto">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:210px; text-align: center" href="dflReporteEmpReg.aspx">Empleados Registrados</a>&nbsp;&nbsp;&nbsp;
            Genera un reporte de los empleados registrados activos
            <br />
            <br />
        </div>
        <br />

        
        <div style="text-align: center">
            <a class="boton"; style="font-family:'Tw Cen MT'; color:#ffffff; width:100px; text-align: center" href="dflInicioA.aspx">Inicio</a>
            <br />
            <br />
        </div>
    </div>
</asp:Content>

