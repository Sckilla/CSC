<%@ Page Title="" Language="C#" MasterPageFile="~/mpEmpleado.master" AutoEventWireup="true" CodeFile="dflCatalogoBE.aspx.cs" Inherits="dflCatalogoBE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background:#ffffff; text-align:center">
        <div class="TituloPaginaN">
            CATÁLOGO
        </div>
        <div>
            <asp:datalist runat="server" CellPadding="0" DataKeyField="ID" DataSourceID="sdsBuscar" RepeatColumns="4" Width="100%" OnItemCommand="Unnamed1_ItemCommand">
                <ItemTemplate>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' Visible="False" />
                    <asp:Label ID="FOTOLabel" runat="server" Text='<%# Eval("FOTO") %>' Visible="False" />
                    <br />
                    <asp:ImageButton ID="imgbProd" runat="server" CommandName="VerDetalle" CommandArgument='<%# Eval("ID") %>' Height="150px" ImageUrl='<%# Eval("FOTO") %>' Width="150px" />
                    <br />
                    <asp:Label ID="PRODUCTOLabel" runat="server" CssClass="LinkProd" Text='<%# Eval("PRODUCTO") %>' />
                    <br />
                    <asp:Label ID="CODIGOLabel" runat="server" Text='<%# Eval("CODIGO") %>' CssClass="DatosProd" />
                    <br />
                    <asp:Label ID="lblExist" runat="server" Text="Existencias: " CssClass="DatosProd"></asp:Label>
                    <asp:Label ID="EXISTENCIASLabel" runat="server" Text='<%# Eval("EXISTENCIAS") %>' CssClass="DatosProd" />
                    <br />
                    <asp:Label ID="PRECIOLabel" runat="server" Text='<%# Eval("PRECIO", "{0:C}") %>' CssClass="Preciop" />
                    <br />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:datalist>
            <asp:SqlDataSource ID="sdsBuscar" runat="server" ConnectionString="<%$ ConnectionStrings:cnnCSC_2019 %>" SelectCommand="TSP_BuscarProducto" SelectCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:cnnCSC_2019.ProviderName %>">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="a" Name="NOMBRE" SessionField="keyWord" Type="String" />
                    <asp:Parameter DefaultValue="1" Name="TB" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

