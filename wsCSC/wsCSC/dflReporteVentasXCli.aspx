<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdministrador.master" AutoEventWireup="true" CodeFile="dflReporteVentasXCli.aspx.cs" Inherits="dflReporteVentasXCli" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff">
        <div class="TituloPaginaN">
            VENTAS POR CLIENTE<br /><br />
        </div>
        <div style="width:40%; text-align: center; margin: 0 auto" class="Info">
            Configura tu búsqueda
            <asp:Label ID="lbltc" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Label ID="lbltb" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Label ID="lblBusqueda" runat="server" Visible="False"></asp:Label>
        </div>
        <table style="width:40%; text-align: center; margin: 0 auto" class="txt">
            <tr>
                <td>
                    Tipo de búsqueda:
                    <br />
                    <asp:RadioButtonList ID="rblTB" runat="server" CssClass="Link">
                        <asp:ListItem Selected="True">Cve de usuario</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Usuario</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
                <td>
                    Tipo de usuario:
                    <br />
                    
                    <asp:RadioButtonList ID="rblTU" runat="server" CssClass="Link">
                        <asp:ListItem Selected="True">Cliente</asp:ListItem>
                        <asp:ListItem>Empleado</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                </td>
                <td>
                    Buscar<br />
                    <asp:TextBox ID="txtBuscar" runat="server" CssClass="txt" MaxLength="15"></asp:TextBox>
                    <asp:ImageButton ID="imgbBuscar" runat="server" ImageUrl="~/Imagenes/lupa.png" Width="25px" OnClick="imgbBuscar_Click" />
                </td>
            </tr>
            
        </table>
        <div style="width:75%; text-align: center; margin: 0 auto">
            <asp:GridView ID="gvVentas" runat="server" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas" Width="100%" OnSelectedIndexChanging="gvVentas_SelectedIndexChanging" AllowPaging="True" OnPageIndexChanging="gvVentas_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/ver.png" ShowSelectButton="True" HeaderText="Ver">
                    <ControlStyle Height="25px" Width="25px" />
                    <ItemStyle Height="25px" Width="25px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="USUARIO" HeaderText="Usuario" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
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
        <div style="width:90%; margin:0 auto">

            <div style="text-align: center">
                <CR:CrystalReportViewer ID="crvReporte" runat="server" AutoDataBind="true" />
                <br />
                <a class="boton" href="dflMenuRep.aspx">
                    Volver
                </a>
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>

