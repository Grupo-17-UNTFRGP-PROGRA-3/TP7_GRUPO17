<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_GRUPO_17.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Titulo -->
    <div style=" width: 1040px; height: 180px;">
        <h1> Mostrar sucursales seleccionadas </h1>
    </div>

    <!-- Sucursales seleccionadas -->
    <div>
        <asp:GridView ID="gvSucursalesSeleccionadas" runat="server">
        </asp:GridView>
    </div>

</asp:Content>
