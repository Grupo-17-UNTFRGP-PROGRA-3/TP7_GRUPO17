using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_17.clases
{
	public class GestionDeSucursales
	{

        // Constructor
        public GestionDeSucursales() { }

        //Metodos
        public DataTable ObtenerDatos()
        {
            GestionDeDatos datos = new GestionDeDatos();
            return datos.EjecutarConsulta(
            "SELECT [Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] FROM [Sucursal]",
            "Sucursal"
            );
        }

        public DataTable FiltroPorProvincias(string provincia)
        {
            string consulta = "SELECT [Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] " +
            "FROM [Sucursal] INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia " +
            "WHERE DescripcionProvincia = '" + provincia + "'";
            GestionDeDatos datos = new GestionDeDatos();
            return datos.EjecutarConsulta(consulta, "Sucursal");
        }

        public DataTable CargarProvincias()
        {
            GestionDeDatos datos = new GestionDeDatos();
            return datos.EjecutarConsulta("SELECT [DescripcionProvincia] FROM Provincia", "Provincia");
        }

        public DataTable FiltroBuscar(string nombreSucursal, string provincia = null)
        {
            string consulta = "SELECT Id_Sucursal, NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal " +
            "FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia " +
            "WHERE NombreSucursal LIKE '%" + nombreSucursal + "%'";

            if (!string.IsNullOrEmpty(provincia))
            {
                consulta += " AND DescripcionProvincia = '" + provincia + "'";
            }

            GestionDeDatos datos = new GestionDeDatos();
            return datos.EjecutarConsulta(consulta, "Sucursal");
        }
    }

}