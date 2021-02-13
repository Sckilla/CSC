<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdministrador.master" AutoEventWireup="true" CodeFile="dflABCEmpleados.aspx.cs" Inherits="dflABCEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 141px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="background-color:#000">
        <div class="TituloPaginaB" style="text-align:center">
            <br />
            INFORMACIÓN DEL EMPLEADO<br />
            <div class="Link">
                (*) Campos obligatorios
            </div>
        </div>
        <table class="IndiCampos" style="color:#ffffff; border:0; width:710px; text-align: center; margin:0 auto;">
            <tr>
                <td class="auto-style1">
                    Tipo de usuario
                </td>
                <td>

                    <asp:DropDownList ID="dwlTipoE" runat="server" Width="200" CssClass="txt">
                    </asp:DropDownList>

                    &nbsp;</td>
                <td style="color:#920101">
                    *</td>
                <td>

                    &nbsp;</td>
            </tr>


            <tr>
                <td class="auto-style1" >
                    Nombre 
                </td>
                <td >

                    <asp:TextBox ID="txtNombreEmp" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtNombreEmp" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Apellido Paterno
                </td>
                <td class="auto-style3">

                    <asp:TextBox ID="txtApePaEmp" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApePaEmp" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Apellido Materno
                </td>
                <td >

                    <asp:TextBox ID="txtApeMatEmp" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td>

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApeMatEmp" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Edad
                </td>
                <td >

                    <asp:TextBox ID="txtEdad" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Edades Válidas1-99" ForeColor="#CC0000" ControlToValidate="txtEdad" ValidationExpression="[1-9][0-9]{0,1}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Sexo
                </td>
                <td >

                    <asp:TextBox ID="txtSexo" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td >

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Masculino o Femenino" ForeColor="#CC0000" ControlToValidate="txtSexo" ValidationExpression="(Masculino|Femenino|Sin especificar)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Correo Electrónico
                </td>
                <td >

                    <asp:TextBox ID="txtCorreoElEmp" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td >

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Aa#_.-@algo[.aaa.aa]" ForeColor="#CC0000" ControlToValidate="txtCorreoElEmp" ValidationExpression="([A-Z]|[a-z]|[0-9]|.|_|-)+@[a-z]+((.[a-z]{3})|(.[a-z]{2}))+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Teléfono
                </td>
                <td >

                    <asp:TextBox ID="txtTelEmp" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td>

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="###-#######" ForeColor="#CC0000" ControlToValidate="txtTelEmp" ValidationExpression="\d{3}-\d{7}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Dirección
                </td>
                <td >

                    <asp:TextBox ID="txtDirEmp" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Aa#._- Aa#._-" ForeColor="#CC0000" ControlToValidate="txtDirEmp" ValidationExpression="(\w+)(\s\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Fotografía
                </td>
                <td >
                    
                    <asp:ImageButton ID="imgCargar" runat="server" Height="70px" OnClick="imgCargar_Click" Width="77px" style="margin-left: 9px" BorderStyle="Solid" ImageUrl="~/Imagenes/Adusuario.png" />
                    
                    <br />
                    
                    <asp:FileUpload ID="fluCargarFoto" runat="server" CssClass="txt" />                    
                    <asp:Label ID="HDDRutaFisica" runat="server" Enabled="False" Visible="False"></asp:Label>

                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    Nombre de usuario
                </td>
                <td class="auto-style2">

                    <asp:TextBox ID="txtNombreUsuEmp" runat="server" Width="300px" CssClass="txt" MaxLength="8"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Aa#Aa#Aa" ForeColor="#CC0000" ControlToValidate="txtNombreUsuEmp" ValidationExpression="([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <asp:Label ID="lblContraseñaAc" runat="server" Text="Contraseña Actual"></asp:Label>
                </td>
                <td >

                    <asp:TextBox ID="txtContrasAEmp" runat="server" Width="300px" CssClass="txt" TextMode="Password" MaxLength="15"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:Label ID="lblIPassA" runat="server" Text="Escribe la contraseña actual" ForeColor="#CC0000"></asp:Label>

                </td>
            </tr>
             <tr>
                <td class="auto-style1" >
                    <asp:Label ID="lblContraseñan" runat="server" Text="Nueva Contraseña"></asp:Label>
                </td>
                <td >

                    <asp:TextBox ID="txtContraseñaEmp" runat="server" Width="300px" CssClass="txt" TextMode="Password" MaxLength="15"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:Label ID="lblIPassN" runat="server" Text="Escribe la nueva contraseña" ForeColor="#CC0000"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <asp:Label ID="lblConfCont" runat="server" Text="Confirmar Contraseña "></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtConfContr" runat="server" Width="300px" CssClass="txt" TextMode="Password" MaxLength="15"></asp:TextBox>
                </td>
                <td style="color:#920101">
                </td>
                <td>
                    <asp:Label ID="lblPass" runat="server" Enabled="False" Visible="False"></asp:Label>
                    <asp:Label ID="ocultar" runat="server" Enabled="False" Visible="False"></asp:Label>
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
        <div class="Herramienta" style="width:478px; margin: 0 auto">
             <asp:Label ID="lblID" runat="server" Enabled="False" Visible="False"></asp:Label>
             <br />
            Buscar por nombre de usuario:
            &nbsp; 
            <asp:TextBox ID="txtbuscarE" runat="server" Height="16px" Width="157px"></asp:TextBox>
            &nbsp; 
            <asp:ImageButton ID="imgbBuscar" runat="server" ImageUrl="~/Imagenes/lupa.png" style="width:23px; height:23px" OnClick="imgbBuscar_Click"/>
        </div>
        <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="True" CellPadding="4" GridLines="Horizontal" PageSize="1" HorizontalAlign="Center" AutoGenerateColumns="False" ForeColor="Black" OnSelectedIndexChanging="gvEmpleado_SelectedIndexChanging" OnPageIndexChanging="gvEmpleado_PageIndexChanging" OnRowDeleting="gvEmpleado_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="Tablas">
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
                <asp:BoundField DataField="USU_NOMBRE" HeaderText="Empleado" />
                <asp:BoundField DataField="EMAIL" HeaderText="E-Mail" />
                <asp:BoundField DataField="TIPO" HeaderText="Tipo de empleado" />
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

