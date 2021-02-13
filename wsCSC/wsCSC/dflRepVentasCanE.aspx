<%@ Page Title="" Language="C#" MasterPageFile="~/mpEmpleado.master" AutoEventWireup="true" CodeFile="dflRepVentasCanE.aspx.cs" Inherits="dflRepVentasCanE" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN">
            COMPRAS CANCELADAS<br /><br />
        </div>
        <div style="width:90%; margin:0 auto">

            <CR:CrystalReportViewer ID="crvVentas" runat="server" AutoDataBind="true" />

            <div style="text-align: center">
                <br />
                <a class="boton" href="dflMenuVentasE.aspx">
                    Volver
                </a>
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>

