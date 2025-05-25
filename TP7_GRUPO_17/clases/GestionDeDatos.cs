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
        //propiedades
        private const string cadenaConexion = @"Data Source = localhost\sqlexpress;Initial Catalog=BDSucursales; Integrated Security=True;TrustServerCertificate=True";
        
        
        public GestionDeDatos() { }
         // Métodos
        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable EjecutarConsulta(string consultaSql, string nombreTabla)
        {
            SqlConnection conn = ObtenerConexion();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(consultaSql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, nombreTabla);
                return ds.Tables[nombreTabla];
            }
            finally
            {
                conn.Close();
            }


        }
    }
}