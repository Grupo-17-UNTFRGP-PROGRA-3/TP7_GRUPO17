using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace TP7_GRUPO_17
{
    public class GestionDeDatos
    {
        private const string cadenaConexion = @"Data Source = localhost\sqlexpress;Initial Catalog=BDSucursales; Integrated Security=True;TrustServerCertificate=True";
        private string sqlConsulta;

        public GestionDeDatos() { }
       
        public DataSet ObtenerDatos ()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            conn.Open();
            string sql = "SELECT[Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal] " +
                "FROM[Sucursal]";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sql, cadenaConexion);
            DataSet dt = new DataSet();
            sqlDA.Fill(dt, "DescripcionSucursal");
            conn.Close();
            return dt;
        }

        public DataTable FiltroPorProvincias(string sqlEvento)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            conn.Open();
            string sql = "SELECT [Id_Sucursal], [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal]" +
                " FROM [Sucursal] INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia" +
                " WHERE DescripcionProvincia = '" + sqlEvento + "'";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sql, cadenaConexion);
            DataSet dt = new DataSet();
            sqlDA.Fill(dt);
            conn.Close();
            return dt.Tables[0];
        }
        public DataSet CargarProvincias()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            conn.Open();
            string sql = "SELECT [DescripcionProvincia] FROM Provincia";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sql, cadenaConexion);
            DataSet dt = new DataSet();
            sqlDA.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataSet FiltroBuscar(string sqlEvento, string provSeleccionada) 
        {

            SqlConnection conn = new SqlConnection(cadenaConexion);
            conn.Open();
            string sql = "SELECT Id_Sucursal, NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE DescripcionProvincia = '" + provSeleccionada + "' AND NombreSucursal LIKE '%" +sqlEvento + "%'";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sql, cadenaConexion);
            DataSet dt = new DataSet();
            sqlDA.Fill(dt);
            conn.Close();
            return dt;
        }






    }
}