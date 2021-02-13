<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflDescripVentaC.aspx.cs" Inherits="dflDescripVentaC" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div style="width:90%; margin:0 auto; text-align: center">

            <CR:CrystalReportViewer ID="crvVenta" runat="server" AutoDataBind="true" />
        <div style="text-align: center">
                    <br />
                    <a class="boton" href="dflInicioC.aspx">
                        Volver
                    </a>
                </div>
                <br />
                <br />
        </div>
    </div>
</asp:Content>

