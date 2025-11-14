using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Laboratorio17
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["db.Name"]; //error de conexión debido a que el connectionString tenia otro nombre distinto al que aparece en el WebConfig.
            SqlConnection conexion = new SqlConnection(connString.ConnectionString);

            //Uso de "using" para asegurar que el lector se cierre automaticamente cuando termine.

            using (SqlCommand cmd = new SqlCommand("SalesByCategory", conexion)) //creación del objeto "cmd" para ejecutar un comando almacenado "SalesByCategory" en una conexión SQL.
            {
                cmd.CommandType = CommandType.StoredProcedure;  //especifica que el comando es un procedimiento almacenado, no una consulta SQL directa tipo SELECT.
                cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = "Seafood";  //agrega un parámetro al comando llamado "@CategoryName" de tipo VarChar y le asigna el valor "Seafood".
                conexion.Open();  //abre la conexión a la base de datos, se usa antes del data reader.

                using (SqlDataReader reader = cmd.ExecuteReader())  //ejecuta el procedimiento almacenado y devuelve los resultados en forma de tabla.
                {
                    if (reader.HasRows)  //verifica que el lector tiene al menos una fila y evita leer si no hay datos.
                    {
                        if (reader.Read())  //lee la primera fila del conjunto de resultados.
                        {
                            GridV.DataSource = reader;  //conectamos los datos al control GridView.
                            GridV.DataBind();  //toma los datos del lector y los muestra en pantalla.
                        }

                    }

                }
            }
        }
    }
}