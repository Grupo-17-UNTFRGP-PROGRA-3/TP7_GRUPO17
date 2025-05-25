<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionados.aspx.cs" Inherits="TP7_GRUPO_17.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Titulo -->
    <div style=" width: 1040px; height: 180px;">
        <h1> Mostrar sucursales seleccionadas</h1>
        <h1> &nbsp;<asp:Label ID="txtSinSucursales" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
        </h1>
    </div>

    <!-- Sucursales seleccionadas -->
    <div>
        <asp:GridView ID="gvSucursalesSeleccionadas" runat="server">
        </asp:GridView>
        <br />
    </div>

    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Selección" />

</asp:Content>
