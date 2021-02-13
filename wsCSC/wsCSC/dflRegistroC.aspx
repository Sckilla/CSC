<%@ Page Title="" Language="C#" MasterPageFile="~/mpGeneral.master" AutoEventWireup="true" CodeFile="dflRegistroC.aspx.cs" Inherits="dflRegistroC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #920101;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#000">
        <div class="TituloPaginaB" style="text-align:center">
            <br />
            REGISTRO
            <br />
        </div>
        <table class="IndiCampos" style="color:#ffffff; border:0; width:700px; text-align: center; margin:0 auto;">
            
            <tr>
                <td >
                    Nombre 
                </td>
                <td >

                    <asp:TextBox ID="txtNombreEmp" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtNombreEmp" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Apellido Paterno
                </td>
                <td >

                    <asp:TextBox ID="txtApePaEmp" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td class="auto-style1">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revApePat" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApePaEmp" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Apellido Materno
                </td>
                <td >

                    <asp:TextBox ID="txtApeMatEmp" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td>

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revApeMat" runat="server" ErrorMessage="Aaaa Aaaa" ForeColor="#CC0000" ControlToValidate="txtApeMatEmp" ValidationExpression="([A-Z][a-z]+)"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Edad
                </td>
                <td >

                    <asp:TextBox ID="txtEdad" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revEdad" runat="server" ErrorMessage="Edades Válidas1-99" ForeColor="#CC0000" ControlToValidate="txtEdad" ValidationExpression="[1-9][0-9]{0,1}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Sexo
                </td>
                <td >

                    <asp:TextBox ID="txtSexo" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

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

                    <asp:TextBox ID="txtCorreoElEmp" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td>

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Aa#_.-@algo[.aaa.aa]" ForeColor="#CC0000" ControlToValidate="txtCorreoElEmp" ValidationExpression="([A-Z]|[a-z]|[0-9]|.|_|-)+@[a-z]+((.[a-z]{3})|(.[a-z]{2}))+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Teléfono
                </td>
                <td >

                    <asp:TextBox ID="txtTelEmp" runat="server" Width="400px" CssClass="txt" MaxLength="11"></asp:TextBox>

                </td>
                <td>

                </td>
                <td>

                    <asp:RegularExpressionValidator ID="revTel" runat="server" ErrorMessage="###-#######" ForeColor="#CC0000" ControlToValidate="txtTelEmp" ValidationExpression="\d{3}-\d{7}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Dirección
                </td>
                <td >

                    <asp:TextBox ID="txtDirEmp" runat="server" Width="400px" CssClass="txt"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="RevDir" runat="server" ErrorMessage="Aa#._- Aa#._-" ForeColor="#CC0000" ControlToValidate="txtDirEmp" ValidationExpression="(\w+)(\s\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Fotografía
                </td>
                <td >
                    
                    <asp:ImageButton ID="imgCargar" runat="server" Height="70px" OnClick="imgCargar_Click" Width="77px" style="margin-left: 9px" BorderStyle="Solid" ImageUrl="~/Imagenes/Adusuario.png" />
                    
                    <br />
                    
                    <asp:FileUpload ID="fluCargarFoto" runat="server" CssClass="txt" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="HDDRutaFisica" runat="server" Text="[ ]" Enabled="False" Visible="False"></asp:Label>

                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td >
                    Nombre de usuario
                </td>
                <td >

                    <asp:TextBox ID="txtNombreUsuEmp" runat="server" Width="400px" CssClass="txt" MaxLength="8"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
                <td>

                    <asp:RegularExpressionValidator ID="revUsuario" runat="server" ErrorMessage="Aa#Aa#Aa" ForeColor="#CC0000" ControlToValidate="txtNombreUsuEmp" ValidationExpression="([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])([A-Z]|[a-z]|[0-9])+"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Contraseña
                </td>
                <td >

                    <asp:TextBox ID="txtContrasEmp" runat="server" Width="400px" TextMode="Password" CssClass="txt" MaxLength="15"></asp:TextBox>

                </td>
                <td style="color:#920101">
                    *</td>
            </tr>
            <tr>
                <td>
                    Confirmar Contraseña
                </td>
                <td >
                    <asp:TextBox ID="txtConfContr" runat="server" Width="400px" TextMode="Password" CssClass="txt" MaxLength="15"></asp:TextBox>
                </td>
                <td style="color:#920101">
                    *</td>
            </tr>

        </table>
        <div style="width:120px; margin: 0 auto">

            <br />

            <asp:ImageButton ID="imgbLimpiar" runat="server" src="Imagenes/clean.png" Width="50px" Height="50px" OnClick="imgbLimpiar_Click"/>
            &nbsp;&nbsp;
            <asp:ImageButton ID="imgbGuardar" runat="server" src="Imagenes/Save.png" Width="50px" Height="50px" OnClick="imgbGuardar_Click"/>

            

        </div>
    </div>
</asp:Content>

