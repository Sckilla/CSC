<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdministrador.master" AutoEventWireup="true" CodeFile="dflABCClientes.aspx.cs" Inherits="dflABCClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#000">
        <div class="TituloPaginaB" style="text-align:center">
            <br />
            INFORMACIÓN DEL CLIENTE
            <div class="Link">
                (*) Campos obligatorios
            </div>
        </div>

        <table class="IndiCampos" style="color:#ffffff; border:0; width:710px; text-align: center; margin:0 auto;">
            
            <tr>
                <td class="auto-style1">
                    Nombre 
                </td>
                <td class="auto-style2">

                    <asp:TextBox ID="txtNombreCli" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtNombreCli" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Apellido Paterno
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtApePaCli" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revApePat" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApePaCli" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
                
            </tr>
            <tr>
                <td>
                    Apellido Materno
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtApeMatCli" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revApeMat" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApeMatCli" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Edad
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtEdad" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revEdad" runat="server" ErrorMessage="Edades Válidas1-99" ForeColor="#CC0000" ControlToValidate="txtEdad" ValidationExpression="[1-9][0-9]{0,1}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Sexo
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtSexo" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revSexo" runat="server" ErrorMessage="Masculino o Femenino" ForeColor="#CC0000" ControlToValidate="txtSexo" ValidationExpression="(Masculino|Femenino|Sin especificar)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Correo Electrónico
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtCorreoElCli" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Aa#_.-@algo[.aaa.aa]" ForeColor="#CC0000" ControlToValidate="txtCorreoElCli" ValidationExpression="([A-Z]|[a-z]|[0-9]|.|_|-)+@[a-z]+((.[a-z]{3})|(.[a-z]{2}))+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Teléfono
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtTelCli" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revTel" runat="server" ErrorMessage="###-#######" ForeColor="#CC0000" ControlToValidate="txtTelCli" ValidationExpression="\d{3}-\d{7}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Dirección
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtDirCli" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="RevDir" runat="server" ErrorMessage="Aa#._- Aa#._-" ForeColor="#CC0000" ControlToValidate="txtDirCli" ValidationExpression="(\w+)(\s\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Fotografía
                </td>
                <td class="auto-style3">
                    
                    <asp:ImageButton ID="imgCargar" runat="server" Height="70px" OnClick="imgCargar_Click" Width="77px" style="margin-left: 9px" BorderStyle="Solid" ImageUrl="~/Imagenes/Adusuario.png" />
                    
                    <br />
                    
                    <asp:FileUpload ID="fluCargarFoto" runat="server" CssClass="txt" />
                    
                    <asp:Label ID="HDDRutaFisica" runat="server" Enabled="False" Visible="False"></asp:Label>

                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Nombre de usuario
                </td>
                <td class="auto-style2">

                    <asp:TextBox ID="txtNombreUsuCli" runat="server" Width="300px" CssClass="txt" MaxLength="8"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revUsuario" runat="server" ErrorMessage="Aa#Aa#Aa" ForeColor="#CC0000" ControlToValidate="txtNombreUsuCli" ValidationExpression="([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblContraseñaA" runat="server" Text="Contraseña Actual"></asp:Label>
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtContrasCliA" runat="server" Width="300px" CssClass="txt" TextMode="Password" MaxLength="15"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    &nbsp;</td>
                <td>

                    <asp:Label ID="lblIContA" runat="server" Text="Esctribe la contraseña actual" ForeColor="#CC0000"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblContraseñaN" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtContrasCliN" runat="server" Width="300px" CssClass="txt" TextMode="Password" MaxLength="15"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    &nbsp;</td>
                <td>

                    <asp:Label ID="lblIContN" runat="server" Text="Escribe la nueva contraseña" ForeColor="#CC0000"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblConfC" runat="server" Text="Confirmar Contraseña"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtConfContr" runat="server" Width="300px" CssClass="txt" TextMode="Password" MaxLength="15"></asp:TextBox>
                </td>
                <td style="color:#920101">
                    &nbsp;</td>
                <td>

                    <asp:Label ID="lblPass" runat="server" Enabled="False" Visible="False"></asp:Label>
                    <asp:Label ID="Ocultar" runat="server" Enabled="False" Visible="False"></asp:Label>
                </td>
            </tr>

        </table>
        <div style="width:120px; margin:0 auto; ">

            <asp:ImageButton ID="imgbCambiarC" runat="server" ImageUrl="~/Imagenes/CAMBCONT.png" Width="100%" OnClick="imgbCambiarC_Click" />
            
        </div>
        <div style="width:125px; margin: 0 auto">

            <br />

            <asp:ImageButton ID="imgbLimpiar" runat="server" src="Imagenes/clean.png" Width="30px" Height="30px" OnClick="imgbLimpiar_Click"/>
            &nbsp;&nbsp;
            <asp:ImageButton ID="imgbGuardar" runat="server" src="Imagenes/Save.png" Width="30px" Height="30px" OnClick="imgbGuardar_Click"/>
            &nbsp;&nbsp;
            <asp:ImageButton ID="imgModificar" runat="server" src="Imagenes/mod.png" Width="30px" Height="30px" OnClick="imgbModificar_Click"/>
             

        </div>
        <div class="Herramienta" style="width:285px; margin: 0 auto">
             <asp:Label ID="lblID" runat="server" Enabled="False" Visible="False"></asp:Label>
             <br />
            Buscar:
            &nbsp; 
            <asp:TextBox ID="txtbuscarC" runat="server" Height="16px" Width="157px" CssClass="txt"></asp:TextBox>
            &nbsp; 
            <asp:ImageButton ID="imgbBuscar" runat="server" ImageUrl="~/Imagenes/lupa.png" style="width:23px; height:23px" OnClick="imgbBuscar_Click"/>
        </div>
        <asp:GridView ID="gvClientes" runat="server" AllowPaging="True" CellPadding="4" GridLines="Horizontal" PageSize="1" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" OnSelectedIndexChanging="gvEmpleado_SelectedIndexChanging" OnPageIndexChanging="gvEmpleado_PageIndexChanging" OnRowDeleting="gvEmpleado_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/vaciar.png" ShowSelectButton="True">
                <ControlStyle Height="25px" Width="25px" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/delt.png" ShowDeleteButton="True">
                <ControlStyle Height="27px" Width="27px" />
                </asp:CommandField>
                <asp:ImageField DataAlternateTextField="FOTO" DataAlternateTextFormatString="FOTO" DataImageUrlField="FOTO" HeaderText="Fotografía">
                    <ControlStyle Height="25px" Width="25px" />
                </asp:ImageField>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="NOMBRE" HeaderText="Cliente" />
                <asp:BoundField DataField="EMAIL" HeaderText="E-Mail" />
                <asp:BoundField DataField="USUARIO" HeaderText="Usuario" />
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

