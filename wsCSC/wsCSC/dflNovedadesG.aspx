﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpGeneral.master" AutoEventWireup="true" CodeFile="dflNovedadesG.aspx.cs" Inherits="dflNovedadesG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 0 auto; text-align: center; background-color:#ffffff">
        <div class="TituloPaginaN">
            NOVEDADES
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
                    <asp:Label ID="PRECIOLabel" runat="server" CssClass="Preciop" Text='<%# Eval("PRECIOF", "{0:C}") %>' />
                    <br />
                </ItemTemplate>
            </asp:DataList>
        <asp:SqlDataSource ID="sdsProductos" runat="server" ConnectionString="<%$ ConnectionStrings:BD_CSC_2018ConnectionString %>" SelectCommand="TSP_ListarProdFecha" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="TIPO" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />

        </div>
</asp:Content>

