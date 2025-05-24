<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionados.aspx.cs" Inherits="TP7_GRUPO_17.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1041px; height: 181px; margin-left: 40px;">
        <div style="display: flex; align-items: flex-start">

            <!-- Datalist (izquierda) -->
            <div style="flex: 0 0 300px; margin-right: 20px; margin-top: 250px;">
                <asp:DataList ID="dlProvincias" runat="server" >
                    <ItemTemplate>
                        <asp:Button ID="btnIDProvincias"
                                    runat="server"
                                    Text='<%# Eval( "DescripcionProvincia") %>'
                                    style="width: 250px;
                                           height: 40px;
                                           margin-bottom: 45px;
                                           font-size: 14px;"
                                           CommandArgument='<%# Bind("DescripcionProvincia") %>'
                                           CommandName="eventoFiltrar"
                                           OnCommand="btnDlProvincias_Command"/>
                    </ItemTemplate>
                </asp:DataList>
            </div>

            <!-- Listview (derecha) -->
            <div style="flex: 1;">

                <!-- Titulo -->
                <h1>Listado de sucursales</h1>

                <!-- Busqueda por nombre de sucursal -->
                <asp:Label ID="lblBusquedaSucursal" runat="server" Text="Busqueda por nombre de sucursal  "></asp:Label>
                <asp:TextBox ID="txtBusquedaSucursal" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                <br />

                <asp:ListView ID="LVSucursales" runat="server" GroupItemCount="3" EnableTheming="True" >

                    <EditItemTemplate>
                        <td runat="server" style="background-color: #008A8C; color: #FFFFFF;">NombreSucursal:
                             <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                            <br />
                            URL_Imagen_Sucursal:
                             <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                            <br />
                            DescripcionSucursal:
                             <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                            <br />
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                            <br />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                            <br />
                        </td>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
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
                            <br />
                            URL_Imagen_Sucursal:
                             <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                            <br />
                            DescripcionSucursal:
                             <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                            <br />
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                            <br />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                            <br />
                        </td>
                    </InsertItemTemplate>

                    <ItemTemplate>
                        <td runat="server" style="background-color: #DCDCDC; color: #000000; padding-top: inherit; padding-right: 0px; padding-left: 0px; text-align:center; 
                            width:200px; height:350px;">
                            <div style="
                                display: flex;
                                flex-direction: column;
                                justify-content: space-between;
                                height: 100%;
                                padding: 0px;
                                box-sizing: border-box;
                                text-align: center;">
                                <div>
                                    <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' Font-Bold="True"/>
                                </div>
                                <div>
                                    <asp:ImageButton ID="iBSucursal" runat="server" ImageAlign="Middle" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>'
                                         Style="width: 100%; aspect-ratio: 1 / 1;" />
                                </div>
                                <div style="min-height: 100px;">
                                    <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                </div>
                                <div>
                                    <asp:Button ID="btnSeleccionar"
                                                runat="server"
                                                CommandArgument='<%# Eval("Id_Sucursal") + "-" + Eval("NombreSucursal") + "-" + Eval("DescripcionSucursal") %>'
                                                CommandName="eventoSeleccionar"
                                                OnCommand="btnSeleccionar_Command"
                                                Text="Seleccionar" />
                                </div>
                            </div>
                        </td>
                    </ItemTemplate>

                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
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
                        <td runat="server" style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">NombreSucursal:
                             <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                            <br />
                            URL_Imagen_Sucursal:
                             <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                            <br />
                            DescripcionSucursal:
                             <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                            <br />
                        </td>
                    </SelectedItemTemplate>
                </asp:ListView>
                <br />
            </div>

            <!-- SQL Data Source Sucursales -->
            <div>
            </div>

            <!-- SQL Data Source Provincias -->
            <div>
            </div>

        </div>
    </div>
</asp:Content>
