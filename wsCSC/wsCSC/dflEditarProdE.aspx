<%@ Page Title="" Language="C#" MasterPageFile="~/mpEmpleado.master" AutoEventWireup="true" CodeFile="dflEditarProdE.aspx.cs" Inherits="dflEditarProdE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#000">
        <div class="TituloPaginaB" style="text-align:center">
            <br />
            INFORMACIÓN DEL PRODUCTO
            <br />
        </div>
        <div class="Link" style="text-align:center">
                (*) Campos obligatorios
            </div>
        <table class="IndiCampos" style="color:#ffffff; border:0; width:700px; text-align: center; margin:0 auto;">            
            <tr>
                <td>
                    Tipo de producto
                </td>
                <td>

                    <asp:DropDownList ID="dwlTipop" runat="server" Width="200" CssClass="txt">
                    </asp:DropDownList>

                </td>
                <td style="color:#920101">
                    *
                </td>
            </tr>
            <tr>
                <td>
                    Presentación (unidad)
                </td>
                <td >

                    <asp:DropDownList ID="ddlPresentacion" runat="server" CssClass="txt" Width="200px">
                    </asp:DropDownList>

                </td>
                <td style="color:#920101">
                    *
                </td>
            </tr>
            <tr>
                <td>
                    Estatus
                </td>
                <td >

                    <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="txt" Width="200px">
                    </asp:DropDownList>

                </td>
                <td style="color:#920101">
                    *
                </td>
            </tr>
            <tr>
                <td >
                    Oferta
                </td>
                <td >

                    <asp:DropDownList ID="ddlOferta" runat="server" CssClass="txt" Width="200px">
                    </asp:DropDownList>

                </td>
                <td style="color:#920101">
                    *</td>
                <td >
                   </td>
            </tr>
            <tr>
                <td >
                    Nombre del producto
                </td>
                <td >

                    <asp:TextBox ID="txtNombreProd" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td >
                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtNombreProd" ValidationExpression="([A-Z][a-z]+)(\s[A-Z][a-z]+)*"></asp:RegularExpressionValidator>
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
                    <asp:RegularExpressionValidator ID="revDescripción" runat="server" ErrorMessage="Aa# Aa#" ForeColor="#CC0000" ControlToValidate="txtDescrip" ValidationExpression="([A-Z]([a-z]|[0-9])+)(\s([A-Z]|[a-z]|[0-9])+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td>
                    Imagen
                </td>
                <td >
                    
                    <asp:ImageButton ID="imgCargar" runat="server" Height="70px" OnClick="imgCargar_Click" Width="77px" style="margin-left: 9px" BorderStyle="Solid" ImageUrl="~/Imagenes/prod.png" />
                    
                    <br />
                    
                    <asp:FileUpload ID="fluCargarFoto" runat="server" CssClass="txt" />
                    
                    <asp:Label ID="HDDRutaFisica" runat="server" Text="" Enabled="False" Visible="False"></asp:Label>

                </td>
                <td style="color:#920101">
                    *</td>
            </tr>
            <tr>
                <td >
                    Precio
                </td>
                <td >

                    <asp:TextBox ID="txtPrecio" runat="server" Width="400px" CssClass="txt" MaxLength="8"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td >
                    <asp:RegularExpressionValidator ID="revPrecio" runat="server" ErrorMessage="##.##" ForeColor="#CC0000" ControlToValidate="txtPrecio" ValidationExpression="((0.)|([1-9][0-9]*.))[0-9]{2}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td>
                    Existencia
                </td>
                <td >

                    <asp:TextBox ID="txtExist" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td >
                    <asp:RegularExpressionValidator ID="revExixtencia" runat="server" ErrorMessage="###" ForeColor="#CC0000" ControlToValidate="txtExist" ValidationExpression="(0)|([1-9][0-9]*)"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td>
                    Codigo
                </td>
                <td >

                    <asp:TextBox ID="txtCodigo" runat="server" Width="400px" CssClass="txt" MaxLength="6"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td >
                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ErrorMessage="AA####" ForeColor="#CC0000" ControlToValidate="txtCodigo" ValidationExpression="[A-Z]{2}[0-9]{4}"></asp:RegularExpressionValidator>
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
            <asp:TextBox ID="txtbuscarP" runat="server" Height="16px" Width="157px" CssClass="txt"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="imgbBuscar" runat="server" ImageUrl="~/Imagenes/lupa.png" style="width:23px; height:23px" OnClick="imgbBuscar_Click"/>
            &nbsp;<asp:CheckBox ID="cbBajas" runat="server" CssClass="Derechos" Text="Productos con baja" />
        </div>
        <asp:GridView ID="gvProductos" runat="server" AllowPaging="True" CellPadding="4" GridLines="Horizontal" PageSize="1" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" OnSelectedIndexChanging="gvProductos_SelectedIndexChanging" OnPageIndexChanging="gvProductos_PageIndexChanging" OnRowDeleting="gvProductos_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/vaciar.png" ShowSelectButton="True" InsertVisible="False">
                <ControlStyle Height="25px" Width="25px" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/delt.png" ShowDeleteButton="True">
                <ControlStyle Height="27px" Width="27px" />
                </asp:CommandField>
                <asp:ImageField DataAlternateTextField="FOTO" DataAlternateTextFormatString="FOTO" DataImageUrlField="FOTO" HeaderText="Fotografía">
                    <ControlStyle Height="25px" Width="25px" />
                </asp:ImageField>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" />
                <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                <asp:BoundField DataField="TIPO" HeaderText="Tipo de producto" />
                <asp:BoundField DataField="PRECIO" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="EXISTENCIAS" HeaderText="Existencias" />
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

