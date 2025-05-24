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
            GestionDeDatos gestionDeDatos = new GestionDeDatos();
            if(!IsPostBack)
            {
                dlProvincias.DataSource = gestionDeDatos.CargarProvincias();
                dlProvincias.DataBind();
                LVSucursales.DataSource = gestionDeDatos.ObtenerDatos();
                LVSucursales.DataBind();
            }
            //else
            //{
            //    if (ViewState["provSel"] == null)
            //    {
            //        LVSucursales.DataSource = gestionDeDatos.ObtenerDatos();
            //        LVSucursales.DataBind();
            //    }
            //    else
            //    {
            //        LVSucursales.DataSource = gestionDeDatos.FiltroPorProvincias(ViewState["provSel"].ToString());
            //        LVSucursales.DataBind();
            //    }
            //}
        }

        protected void btnDlProvincias_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoFiltrar")
            {
                string filtro = e.CommandArgument.ToString();
                GestionDeDatos gdd = new GestionDeDatos();
                LVSucursales.DataSource = gdd.FiltroPorProvincias(filtro);
                LVSucursales.DataBind();
                ViewState["provSel"] = filtro;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GestionDeDatos gdd = new GestionDeDatos();
            string filtro = txtBusquedaSucursal.Text;
            if (filtro == string.Empty) 
            { 
                LVSucursales.DataSource = gdd.ObtenerDatos(); 
                LVSucursales.DataBind();
            }
            else
            {
                if (ViewState["provSel"] == null)
                {
                    LVSucursales.DataSource = gdd.FiltroBuscar(filtro);
                    LVSucursales.DataBind();
                }
                else
                {
                    LVSucursales.DataSource = gdd.FiltroBuscar(filtro, ViewState["provSel"].ToString());
                    LVSucursales.DataBind();
                }
            }
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

            GestionDeDatos gdd = new GestionDeDatos();

            if (ViewState["provSel"] == null)
                LVSucursales.DataSource = gdd.ObtenerDatos();
            else
                LVSucursales.DataSource = gdd.FiltroPorProvincias(ViewState["provSel"].ToString());

            LVSucursales.DataBind();
        }
    }
}