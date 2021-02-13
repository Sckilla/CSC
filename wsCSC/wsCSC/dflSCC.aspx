<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflSCC.aspx.cs" Inherits="dflSCC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#ffffff">
        <div style="text-align:center;" class="TituloPaginaN">
            ACERCA DE SANLO'S CAFÉ
        </div>
        <br />
        <p style="width:75%; margin:0 auto; text-align: justify" class="Info">
            Sanlo´s Café es una empresa dedicada a la venta de servicios de hostelería con un ambiente acogedor y artístico en el que nuestros comensales puedan compartir momentos especiales en familia, amigos o en pareja acompañados de deliciosas bebidas, bocadillos y postres naturales. 
        </p>
        <br />
        <p style="width:75%; margin:0 auto; text-align: justify" class="Info">
                La misión de Sanlo´s Café es proporcionar una experiencia única en un espacio cómodo, seguro y agradable acompañado del mejor café de grano de productores mexicanos. 
Como empresa socialmente responsable es crucial el esfuerzo por ser no solo el café más concurrido y reconocido por su originalidad, valores y excelencia en el servicio sino también por el uso de productos regionales de alta calidad.

        </p>
        <br />
        <p style="width:75%; margin:0 auto; text-align: justify" class="Info">
                El segmento de mercado al que va dirigido Sanlo´s Café es amplio estudiantes, profesionistas, artistas, viajeros de nivel socioeconómico medio-alto, datos obtenidos por medio de un estudio de mercado en el cual nos indica que el 96% de nuestro mercado se encuentra en edades de 18 a 40 años y el 4% son personas de 40 a 70 años interesados en el apasionante mundo del café, el arte, la lectura y la convivencia.
        </p>
        <br />
        <div class="Info">
            CONTÁCTANOS
        </div>

        <div style="width:75%; margin:0 auto; text-align: justify" class="Info">
            <table style="width:50%; margin: 0 auto" class="Info">
                <tr>
                    <td>

                        <asp:Image ID="FACEBOOK" runat="server" Height="50px" ImageUrl="~/Imagenes/Facebook.png" Width="50px" />

                    </td>
                    <td>
                        www.facebook.com/sanlos.tezontepec
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Image ID="TWITTER" runat="server" Height="50px" ImageUrl="~/Imagenes/twitter.png" Width="50px" />

                    </td>
                    <td>

                        @SanlosCafe</td>
                </tr>
                <tr>
                    <td>

                        <asp:Image ID="INSTAGRAM" runat="server" Height="50px" ImageUrl="~/Imagenes/Instagram.png" Width="50px" />

                    </td>
                    <td>

                        SanlosCafe</td>
                </tr>
                <tr>
                    <td>

                        <asp:Image ID="GMAIL" runat="server" Height="50px" ImageUrl="~/Imagenes/gmail-icon.png" Width="50px" />

                    </td>
                    <td>

                        sanloscafe0304@gmail.com</td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>

