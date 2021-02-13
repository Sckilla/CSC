<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflComprasC.aspx.cs" Inherits="dflComprasC" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN">
            COMPRAS ACTIVAS
            <br />
        </div>
        <div style="width:75%; text-align: center; margin: 0 auto">
            <asp:GridView ID="gvVentas" runat="server" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" OnRowDeleting="gvVentasC_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas" Width="100%" OnSelectedIndexChanging="gvVentas_SelectedIndexChanging" AllowPaging="True" OnPageIndexChanging="gvVentas_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/delt.png" ShowDeleteButton="True">
                    <ControlStyle Height="27px" Width="27px" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/ver.png" ShowSelectButton="True" HeaderText="Ver">
                    <ControlStyle Height="25px" Width="25px" />
                    <ItemStyle Height="25px" Width="25px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                    <asp:BoundField DataField="SUBTOTAL" DataFormatString="{0:C}" HeaderText="Subtotal" />
                    <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:C}" />
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
        </div>
        <div style="width:90%; margin: 0 auto">
            <br />
            <CR:CrystalReportViewer ID="crvVenta" runat="server" AutoDataBind="true" />
            <br />
            <div style="text-align: center">
                    <a class="boton" href="dflMenuVentasC.aspx">
                        Volver
                    </a>
                </div>
                <br />
                <br />
        </div>
        </div>
</asp:Content>

