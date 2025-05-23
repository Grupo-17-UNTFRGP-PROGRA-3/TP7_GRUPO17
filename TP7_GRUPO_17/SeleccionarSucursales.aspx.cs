using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_17
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sucursales"] != null)
                {
                    DataTable sucursalesSeleccionadas = (DataTable)Session["sucursales"];
                    gvSucursalesSeleccionadas.DataSource = sucursalesSeleccionadas;
                    gvSucursalesSeleccionadas.DataBind();
                }
                else
                {
                    gvSucursalesSeleccionadas.DataSource = null;
                    gvSucursalesSeleccionadas.DataBind();
                }
            }

        }
    }
}