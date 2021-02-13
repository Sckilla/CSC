<%@ Page Title="" Language="C#" MasterPageFile="~/mpEmpleado.master" AutoEventWireup="true" CodeFile="dflOfertasE.aspx.cs" Inherits="dflOfertasE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 0 auto; text-align: center; background-color:#ffffff">
        <div class="TituloPaginaN">
            <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPaginaN">OFERTAS</asp:Label>
        </div>

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
                    <asp:Label ID="PrecioAnt" runat="server" CssClass="PrecioR" Text='<%# Eval("PRECIO", "{0:C}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="PRECIOLabel" runat="server" CssClass="Preciop" Text='<%# Eval("PRECIOF", "{0:C}") %>' />
                    <br />
                </ItemTemplate>
            </asp:DataList>
        <asp:SqlDataSource ID="sdsProductos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnCSC_2019 %>" SelectCommand="TSP_ListarProdOfer" SelectCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:cnnCSC_2019.ProviderName %>">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="TIPO" SessionField="prodId" Type="Int32" />
                <asp:SessionParameter DefaultValue="1" Name="P" SessionField="ControlP" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div>
            <br />
            <asp:ImageButton ID="imgbIzq" runat="server" ImageUrl="~/Imagenes/IZQ.png" OnClick="imgbIzq_Click" Width="20px" />
&nbsp;<asp:Label ID="lblNPag" runat="server" CssClass="PrecioG" Text="1"></asp:Label>
&nbsp;<asp:ImageButton ID="imgbDer" runat="server" ImageUrl="~/Imagenes/DER.png" OnClick="imgbDer_Click" Width="20px" />

            <br />

        </div>
    </div>
</asp:Content>

