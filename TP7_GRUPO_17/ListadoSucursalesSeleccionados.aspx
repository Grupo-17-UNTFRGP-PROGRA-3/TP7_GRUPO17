<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionados.aspx.cs" Inherits="TP7_GRUPO_17.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style=" width: 1041px; height: 181px; margin-left: 40px;">
         <h1>Listado de sucursales</h1>
         <br />

         <asp:ListView ID="LVSucursales" runat="server" DataSourceID="SDSSucursales" GroupItemCount="3">
            
                 <EditItemTemplate>
                 <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">NombreSucursal:
                     <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                     <br />URL_Imagen_Sucursal:
                     <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                     <br />DescripcionSucursal:
                     <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                     <br />
                     <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                     <br />
                     <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                     <br /></td>
             </EditItemTemplate>
             <EmptyDataTemplate>
                 <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                     <tr>
                         <td>No se han devuelto datos.</td>
                     </tr>
                 </table>
             </EmptyDataTemplate>
             <EmptyItemTemplate>
<td runat="server" />
             </EmptyItemTemplate>
             <GroupTemplate>
                 <tr id="itemPlaceholderContainer" runat="server">
                     <td id="itemPlaceholder" runat="server"></td>
                 </tr>
             </GroupTemplate>
             <InsertItemTemplate>
                 <td runat="server" style="">NombreSucursal:
                     <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                     <br />URL_Imagen_Sucursal:
                     <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                     <br />DescripcionSucursal:
                     <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                     <br />
                     <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                     <br />
                     <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                     <br /></td>
             </InsertItemTemplate>
             <ItemTemplate>
                 <td runat="server" style="background-color:#DCDCDC;color: #000000;">Nombre de la sucursal:
                     <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                     <br />
                     &nbsp;<asp:ImageButton ID="iBSucursal" runat="server" BorderStyle="Solid" ImageAlign="Middle" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' />
                     <br />
                      Descripcion de la sucural:
                     <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                     <br /></td>
             </ItemTemplate>
             <LayoutTemplate>
                 <table runat="server">
                     <tr runat="server">
                         <td runat="server">
                             <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                 <tr id="groupPlaceholder" runat="server">
                                 </tr>
                             </table>
                         </td>
                     </tr>
                     <tr runat="server">
                         <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                             <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                 <Fields>
                                     <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                     <asp:NumericPagerField />
                                     <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                 </Fields>
                             </asp:DataPager>
                         </td>
                     </tr>
                 </table>
             </LayoutTemplate>
             <SelectedItemTemplate>
                 <td runat="server" style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">NombreSucursal:
                     <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                     <br />URL_Imagen_Sucursal:
                     <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                     <br />DescripcionSucursal:
                     <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                     <br /></td>
             </SelectedItemTemplate>
         </asp:ListView>
         <br />
         <asp:SqlDataSource ID="SDSSucursales" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM [Sucursal]"></asp:SqlDataSource>

   </div>

</asp:Content>
