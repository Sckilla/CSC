<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdministrador.master" AutoEventWireup="true" CodeFile="dflABCTipProductos.aspx.cs" Inherits="dflABCTipProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#000">
        <div class="TituloPaginaB" style="text-align:center">
            <br />
            INFORMACIÓN DEL TIPO DE PRODUCTO
            <br />
        </div>
        <div class="Link" style="text-align:center">
                (*) Campos obligatorios
            </div>
        <table class="IndiCampos" style="color:#ffffff; border:0; width:700px; text-align: center; margin:0 auto;">            
            
            <tr>
                <td>
                    Estatus
                </td>
                <td >

                    <asp:DropDownList ID="dwlEstatus" runat="server" CssClass="txt" Width="200px">
                    </asp:DropDownList>

                </td>
                <td style="color:#920101">
                    *
                </td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    Nombre del tipo de producto
                </td>
                <td >

                    <asp:TextBox ID="txtTipoProd" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td >
                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ControlToValidate="txtTipoProd" ValidationExpression="([A-Z][a-z]+)(\s[A-Z][a-z]+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Descripción
                </td>
                <td >

                    <asp:TextBox ID="txtDescrip" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    
                </td>
                <td >
                    <asp:RegularExpressionValidator ID="revDescripción" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ControlToValidate="txtDescrip" ValidationExpression="([A-Z]([a-z]|[0-9])+)(\s([A-Z]|[a-z]|[0-9])+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
           

        </table>
        <div style="width:125px; margin: 0 auto">

            <br />

            <asp:ImageButton ID="imgbLimpiar" runat="server" src="Imagenes/clean.png" Width="30px" Height="30px" OnClick="imgbLimpiar_Click"/>
            &nbsp;&nbsp;
            <asp:ImageButton ID="imgbGuardar" runat="server" src="Imagenes/Save.png" Width="30px" Height="30px" OnClick="imgbGuardar_Click"/>
            &nbsp;&nbsp;
            <asp:ImageButton ID="imgModificar" runat="server" src="Imagenes/mod.png" Width="30px" Height="30px" OnClick="imgbModificar_Click"/>
             

        </div>
        <div class="Herramienta" style="width:410px; margin: 0 auto">
             <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
             <br />
            Buscar:
            &nbsp; 
            <asp:TextBox ID="txtbuscarP" runat="server" Height="16px" Width="157px" CssClass="txt" MaxLength="45"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="imgbBuscar" runat="server" ImageUrl="~/Imagenes/lupa.png" style="width:23px; height:23px" OnClick="imgbBuscar_Click"/>
            &nbsp;<asp:CheckBox ID="cbBajas" runat="server" CssClass="Derechos" Text="Búsqueda con baja" />
        </div>
        <asp:GridView ID="gvTProductos" runat="server" AllowPaging="True" CellPadding="4" GridLines="Horizontal" PageSize="1" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" OnSelectedIndexChanging="gvTProductos_SelectedIndexChanging" OnPageIndexChanging="gvTProductos_PageIndexChanging" OnRowDeleting="gvTProductos_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/vaciar.png" ShowSelectButton="True" InsertVisible="False">
                <ControlStyle Height="25px" Width="25px" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/delt.png" ShowDeleteButton="True">
                <ControlStyle Height="27px" Width="27px" />
                </asp:CommandField>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="TIPO" HeaderText="Tipo de Producto" />
                <asp:BoundField DataField="DESC" HeaderText="Descripción" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>

