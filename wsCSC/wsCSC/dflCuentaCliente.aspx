<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflCuentaCliente.aspx.cs" Inherits="dflCuentaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; background-color:#000000">
    <div style="width:60%; margin:0 auto; background-color:#ffffff">
        <div class="TituloPaginaN" style="text-align:center">
            <br />
            MI INFORMACIÓN
            <div class="Link">
                <asp:Label ID="lblCampOb" runat="server" Text="(*) Campos obligatorios"></asp:Label>
                
            </div>
        </div>

        <table class="IndiCamposN" style="border:0; width:100%; text-align: center; margin:0 auto;">
            
            <tr>
                <td >
                    Nombre 
                </td>
                <td >

                    <asp:TextBox ID="txtNombre" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtNombre" ValidationExpression="([A-Z][a-z]+)(\s[A-Z][a-z]+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Apellido Paterno
                </td>
                <td >

                    <asp:TextBox ID="txtApePa" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revApePat" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApePa" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
                
            </tr>
            <tr>
                <td>
                    Apellido Materno
                </td>
                <td >

                    <asp:TextBox ID="txtApeMat" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revApeMat" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApeMat" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Edad
                </td>
                <td >

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
                <td >

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
                <td >

                    <asp:TextBox ID="txtCorreoEl" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Aa#_.-@algo[.aaa.aa]" ForeColor="#CC0000" ControlToValidate="txtCorreoEl" ValidationExpression="([A-Z]|[a-z]|[0-9]|.|_|-)+@[a-z]+((.[a-z]{3})|(.[a-z]{2}))+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Teléfono
                </td>
                <td >

                    <asp:TextBox ID="txtTel" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revTel" runat="server" ErrorMessage="###-#######" ForeColor="#CC0000" ControlToValidate="txtTel" ValidationExpression="\d{3}-\d{7}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Dirección
                </td>
                <td >

                    <asp:TextBox ID="txtDir" runat="server" Width="300px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revDir" runat="server" ErrorMessage="Aa#._- Aa#._-" ForeColor="#CC0000" ControlToValidate="txtDir" ValidationExpression="(\w+)(\s\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Fotografía
                </td>
                <td >
                    
                    <asp:ImageButton ID="imgCargar" runat="server" Height="70px" OnClick="imgCargar_Click" Width="77px" style="margin-left: 9px" BorderStyle="Groove" ImageUrl="~/Imagenes/Adusuario.png" />
                    
                    <br />
                    
                    <asp:FileUpload ID="fluCargarFoto" runat="server" CssClass="txt" />
                    
                    <asp:Label ID="HDDRutaFisica" runat="server" Enabled="False" Visible="False"></asp:Label>

                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td >
                    Nombre de usuario
                </td>
                <td >

                    <asp:TextBox ID="txtNombreUsu" runat="server" Width="300px" CssClass="txt" MaxLength="8"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revUsu" runat="server" ErrorMessage="Aa#Aa#Aa" ForeColor="#CC0000" ControlToValidate="txtNombreUsu" ValidationExpression="([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblContraseñaA" runat="server" Text="Contraseña Actual"></asp:Label>
                </td>
                <td >

                    <asp:TextBox ID="txtContrasA" runat="server" Width="300px" CssClass="txt" TextMode="Password"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    &nbsp;</td>
                <td>

                    <asp:Label ID="lblIContA" runat="server" Text="Esctriba su contraseña actual" ForeColor="Black"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblContraseñaN" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td >

                    <asp:TextBox ID="txtContrasN" runat="server" Width="300px" CssClass="txt" TextMode="Password"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    &nbsp;</td>
                <td>

                    <asp:Label ID="lblIConfN" runat="server" Text="Escriba su nueva contraseña" ForeColor="Black"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblConfC" runat="server" Text="Confirmar Contraseña"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtConfContr" runat="server" Width="300px" CssClass="txt" TextMode="Password"></asp:TextBox>
                </td>
                <td style="color:#920101">
                    &nbsp;</td>
                <td>

                    <asp:Label ID="lblPass" runat="server" Enabled="False" Visible="False"></asp:Label>
                    <asp:Label ID="Ocultar" runat="server" Enabled="False" Visible="False">0</asp:Label>
                </td>
            </tr>

        </table>
        <div style="width:120px; margin:0 auto; text-align:center">

            <asp:ImageButton ID="imgbCambiarC" runat="server" ImageUrl="~/Imagenes/CAMBCONT.png" Width="100%" OnClick="imgbCambiarC_Click" />
            <asp:ImageButton ID="imgbHabEd" runat="server" ImageUrl="~/Imagenes/HabEd.png" Width="100%" OnClick="imgbHabEd_Click" />

        </div>
        <div style="width:50px; margin:0 auto;">
            <asp:ImageButton ID="imgbGuardar" runat="server" ImageUrl="~/Imagenes/SAVE.png" Width="100%" OnClick="imgbGuardar_Click" />
            <br />
        </div>
    </div>
    </div>
</asp:Content>

