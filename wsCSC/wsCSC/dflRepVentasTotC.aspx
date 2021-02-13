<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflRepVentasTotC.aspx.cs" Inherits="dflRepVentasTotC" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN">
            COMPRAS REALIZADAS<br /><br />
        </div>
        <div style="width:90%; margin:0 auto">

            <CR:CrystalReportViewer ID="crvVentas" runat="server" AutoDataBind="true" />

            <div style="text-align: center">
                <br />
                <a class="boton" href="dflMenuVentasC.aspx">
                    Volver
                </a>
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>

