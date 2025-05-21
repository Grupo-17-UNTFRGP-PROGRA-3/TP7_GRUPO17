using System;
using System.Collections.Generic;
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

        }

        protected void btnDlProvincias_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoFiltrar")
            {
                SDSSucursales.SelectCommand = "SELECT [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM [Sucursal] INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE DescripcionProvincia = '" + e.CommandArgument.ToString() + "'";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}