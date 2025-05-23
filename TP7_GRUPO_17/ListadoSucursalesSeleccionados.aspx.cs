using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_17
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                SDSSucursales.SelectCommand = ViewState["SQL"].ToString();
            }
            else
            {
                string  strSql = "SELECT[Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM[Sucursal]";
                ViewState["SQL"] = strSql;
            }
        }

        protected void btnDlProvincias_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoFiltrar")
            {
                // Convertir en clase GestionDeDatos
                string strSql = "SELECT [Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM [Sucursal] INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE DescripcionProvincia = '" + e.CommandArgument.ToString() + "'";
                ViewState["SQL"] = strSql;
                SDSSucursales.SelectCommand = strSql;
                SDSSucursales.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Convertir en clase GestionDeDatos
            string strSql = "SELECT [Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM [Sucursal] WHERE NombreSucursal LIKE '%" + txtBusquedaSucursal.Text + "%'";
            ViewState["SQL"] = strSql;
            SDSSucursales.SelectCommand = strSql;
            SDSSucursales.DataBind();
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "eventoSeleccionar")
            {
                DataTable sucursalesSeleccionadas = new DataTable();

                string[] datosSucursal = e.CommandArgument.ToString().Split('-');
                string idSucursal = datosSucursal[0];
                string nombreSucursal = datosSucursal[1];
                string descripcionSucursal = datosSucursal[2];

                if (Session["sucursales"] == null)
                {
                    sucursalesSeleccionadas = new DataTable();
                    sucursalesSeleccionadas.Columns.Add("ID_SUCURSAL");
                    sucursalesSeleccionadas.Columns.Add("NOMBRE");
                    sucursalesSeleccionadas.Columns.Add("DESCRIPCION");
                }
                else
                {
                    sucursalesSeleccionadas = (DataTable)Session["sucursales"];
                }

                DataRow row = sucursalesSeleccionadas.NewRow();
                row["ID_SUCURSAL"] = idSucursal;
                row["NOMBRE"] = nombreSucursal;
                row["DESCRIPCION"] = descripcionSucursal;
                sucursalesSeleccionadas.Rows.Add(row);
                Session["sucursales"] = sucursalesSeleccionadas;
            }
        }
    }
}