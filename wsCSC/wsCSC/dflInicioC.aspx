<%@ Page Title="" Language="C#" MasterPageFile="~/mpCliente.master" AutoEventWireup="true" CodeFile="dflInicioC.aspx.cs" Inherits="dflInicioC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div style="margin: 0 auto; text-align: center; background-color:#ffffff">
        <div class="TituloPaginaN">
            BIENVENIDO
        </div>
        <p class="txt" style="width:75%; margin:0 auto; text-align:center">
            Sanlo´s Café es una empresa dedicada a la venta de servicios de hostelería con un ambiente acogedor y artístico en el que nuestros comensales puedan compartir momentos especiales en familia, amigos o en pareja acompañados de deliciosas bebidas, bocadillos y postres naturales. 
        </p>
        <p class="txt" style="width:75%; margin:0 auto; text-align:center">
            Bienvenido a nuestra página web, un lugar que llevará nuestra experiencia hasta tu hogar y te introducirá a nuestro concepto. Revisa y adquiere nuestros productos personalizables y consumiblas de calidad premium
        </p>
            <asp:DataList ID="dlCatálogo" runat="server" BorderStyle="None" CellPadding="0" CssClass="auto-style1" DataKeyField="ID" DataSourceID="sdsProductos" RepeatColumns="4" Width="100%" OnItemCommand="dlCatálogo_ItemCommand">
                <ItemTemplate>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' Visible="False" />
                    <asp:Label ID="FOTOLabel" runat="server" Text='<%# Eval("FOTO") %>' Visible="False" />
                    <br />
                    <asp:ImageButton ID="imgbProd" runat="server" CommandName="VerDetalle" CommandArgument='<%# Eval("ID") %>' Height="150px" ImageUrl='<%# Eval("FOTO") %>' Width="150px" />
                    <br />
                    <asp:Label ID="PRODUCTOLabel" runat="server" CssClass="LinkProd" Text='<%# Eval("PRODUCTO") %>' />
                    <br />
                    <asp:Label ID="CODIGOLabel" runat="server" CssClass="DatosProd" Text='<%# Eval("CODIGO") %>' />
                    <br />
                    &nbsp;<asp:Label ID="lblEx" runat="server" CssClass="DatosProd" Text="Existencias: "></asp:Label>
                    <asp:Label ID="EXISTENCIASLabel" runat="server" CssClass="DatosProd" Text='<%# Eval("EXISTENCIAS") %>' />
                    <br />
                    <asp:Label ID="PRECIOLabel" runat="server" CssClass="Preciop" Text='<%# Eval("PRECIOF", "{0:C}") %>' />
                    <br />
                </ItemTemplate>
            </asp:DataList>
        <asp:SqlDataSource ID="sdsProductos" runat="server" ConnectionString="<%$ ConnectionStrings:BD_CSC_2018ConnectionString %>" SelectCommand="TSP_ListarProdAleat" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="TIPO" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />

        <br />

    </div>
</asp:Content>

