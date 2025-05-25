using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_GRUPO_17.clases;

namespace TP7_GRUPO_17
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GestionDeSucursales GDS = new GestionDeSucursales();
            if (!IsPostBack)
            {
                dlProvincias.DataSource = GDS.CargarProvincias();
                dlProvincias.DataBind();
                LVSucursales.DataSource = GDS.ObtenerDatos();
                LVSucursales.DataBind();
            }
           
        }

        protected void btnDlProvincias_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoFiltrar")
            {
                string filtro = e.CommandArgument.ToString();
                GestionDeSucursales GDS = new GestionDeSucursales();
                LVSucursales.DataSource = GDS.FiltroPorProvincias(filtro);
                LVSucursales.DataBind();
                ViewState["provSel"] = filtro;
                ViewState["resultadoBusqueda"] = null;

            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GestionDeSucursales GDS = new GestionDeSucursales();
            string filtro = txtBusquedaSucursal.Text;

            DataTable resultado;

            if (string.IsNullOrEmpty(filtro))
            {
                resultado = GDS.ObtenerDatos();
                ViewState["resultadoBusqueda"] = null;
                ViewState["provSel"] = null;
            }
            else
            {
                if (ViewState["provSel"] == null)
                    resultado = GDS.FiltroBuscar(filtro);
                else
                    resultado = GDS.FiltroBuscar(filtro, ViewState["provSel"].ToString());
            }

            ViewState["resultadoBusqueda"] = resultado;
            LVSucursales.DataSource = resultado;
            LVSucursales.DataBind();

            txtBusquedaSucursal.Text = string.Empty;
        }


        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
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
                    foreach(DataRow filaSelec in sucursalesSeleccionadas.Rows)
                    {
                        if (filaSelec["ID_SUCURSAL"].ToString() == idSucursal)
                            return;
                    }
                }

                DataRow row = sucursalesSeleccionadas.NewRow();
                row["ID_SUCURSAL"] = idSucursal;
                row["NOMBRE"] = nombreSucursal;
                row["DESCRIPCION"] = descripcionSucursal;
                sucursalesSeleccionadas.Rows.Add(row);
                Session["sucursales"] = sucursalesSeleccionadas;
            }
        }

        protected void LVSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager pager = (DataPager)LVSucursales.FindControl("DataPager1");
            if (pager != null)
                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            if (ViewState["resultadoBusqueda"] != null)
            {
                LVSucursales.DataSource = (DataTable)ViewState["resultadoBusqueda"];
            }
            else
            {
                GestionDeSucursales GDS = new GestionDeSucursales();
                if (ViewState["provSel"] == null)
                    LVSucursales.DataSource = GDS.ObtenerDatos();
                else
                    LVSucursales.DataSource = GDS.FiltroPorProvincias(ViewState["provSel"].ToString());
            }

            LVSucursales.DataBind();
        }

    }
}