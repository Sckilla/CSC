<%@ Page Title="" Language="C#" MasterPageFile="~/mpGeneral.master" AutoEventWireup="true" CodeFile="dflCatalogoPG.aspx.cs" Inherits="dflCatalogoPG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 0 auto; text-align: center; background-color:#ffffff">
        <div class="TituloPaginaN">
            <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPaginaN"></asp:Label>
        </div>
        <asp:DataList ID="dlCatálogo" runat="server" BorderStyle="None" CellPadding="0" CssClass="auto-style1" DataKeyField="ID" DataSourceID="sdsProductos" RepeatColumns="4" Width="100%" OnItemCommand="dlCatálogo_ItemCommand">
                <ItemTemplate>                 
                    TIPO:                 
                    <asp:Label ID="TIPOLabel" runat="server" Text='<%# Eval("TIPO") %>' />
                    <br />
                    ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    CODIGO:
                    <asp:Label ID="CODIGOLabel" runat="server" Text='<%# Eval("CODIGO") %>' />
                    <br />
                    PRODUCTO:
                    <asp:Label ID="PRODUCTOLabel" runat="server" Text='<%# Eval("PRODUCTO") %>' />
                    <br />
                    DESCRIPCION:
                    <asp:Label ID="DESCRIPCIONLabel" runat="server" Text='<%# Eval("DESCRIPCION") %>' />
                    <br />
                    PRESENTACION: <asp:Label ID="PRESENTACIONLabel" runat="server" Text='<%# Eval("PRESENTACION") %>'></asp:Label>
                    <br />
                    FOTO:
                    <asp:Label ID="FOTOLabel" runat="server" Text='<%# Eval("FOTO") %>' />
                    <br />
                    PRECIO:
                    <asp:Label ID="PRECIOLabel" runat="server" Text='<%# Eval("PRECIO") %>' />
                    <br />
                    PRECIOF:
                    <asp:Label ID="PRECIOFLabel" runat="server" Text='<%# Eval("PRECIOF") %>' />
                    <br />
                    OFF_RAZON:
                    <asp:Label ID="OFF_RAZONLabel" runat="server" Text='<%# Eval("OFF_RAZON") %>' />
                    <br />
                    EXISTENCIAS:
                    <asp:Label ID="EXISTENCIASLabel" runat="server" Text='<%# Eval("EXISTENCIAS") %>' />
                    <br />
                    FILA:
                    <asp:Label ID="FILALabel" runat="server" Text='<%# Eval("FILA") %>' />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
        <asp:SqlDataSource ID="sdsProductos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnCSC_2019 %>" SelectCommand="TSP_ListarNProductos" SelectCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:cnnCSC_2019.ProviderName %>">
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

