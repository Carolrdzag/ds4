using Proyecto22.Models.WS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using Proyecto22.Models.WS;

// Maneja los datos y la logica del API

namespace WebApi.Controllers
{
    [RoutePrefix("api/Calculos")]  // ruta base del controlador 
    public class CalculosController : ApiController
    {
        private readonly string connectionString;

        public CalculosController()  // variable que guarda la conexion a SQL
        {
            connectionString = @"Server=.\SQLEXPRESS;Database=CalculadoraDB;Trusted_Connection=True;Encrypt=False;";
        }

        [HttpGet]
        [Route("ObtenerTodos")]  // metodo para obetener todos los calculos
        public IHttpActionResult ObtenerTodos()
        {
            try
            {
                List<Reply> calculos = new List<Reply>();  // lista donde se guardan los datos 

                using (SqlConnection conn = new SqlConnection(connectionString))  // abre la conexion a SQL
                {
                    string query = "SELECT * FROM ResultadosCalculadora ORDER BY Fecha DESC";  // consulta que trae tdoos los datos en forma descendente.
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();  // lee fila por fila
                    while (reader.Read())  // lee cada registro 
                    {
                        // convierte de datos a objetos 
                        calculos.Add(new Reply
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Expresion = reader["Expresion"].ToString(),
                            Resultado = Convert.ToDecimal(reader["Resultado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                }

                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("ObtenerSumas")]
        public IHttpActionResult ObtenerSumas()
        {
            return ObtenerPorOperacion("%+%");
        }

        [HttpGet]
        [Route("ObtenerRestas")]
        public IHttpActionResult ObtenerRestas()
        {
            return ObtenerPorOperacion("%-%");
        }

        [HttpGet]
        [Route("ObtenerMultiplicaciones")]
        public IHttpActionResult ObtenerMultiplicaciones()
        {
            return ObtenerPorOperacion("%x%");
        }

        [HttpGet]
        [Route("ObtenerDivisiones")]
        public IHttpActionResult ObtenerDivisiones()
        {
            return ObtenerPorOperacion("%÷%");
        }

        [HttpGet]
        [Route("ObtenerCalculosRecientes")]
        public IHttpActionResult ObtenerCalculosRecientes(int dias = 7)
        {
            try
            {
                List<Reply> calculos = new List<Reply>();
                DateTime fechaLimite = DateTime.Now.AddDays(-dias);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ResultadosCalculadora WHERE Fecha >= @FechaLimite ORDER BY Fecha DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FechaLimite", fechaLimite);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        calculos.Add(new Reply
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Expresion = reader["Expresion"].ToString(),
                            Resultado = Convert.ToDecimal(reader["Resultado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                }

                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Método reutilizable para operaciones matemáticas, evita repetir codigo, recibe el operador a buscar.
        private IHttpActionResult ObtenerPorOperacion(string operadorLike)
        {
            try
            {
                List<Reply> lista = new List<Reply>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $"SELECT * FROM ResultadosCalculadora WHERE Expresion LIKE @Operacion ORDER BY Fecha DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Operacion", operadorLike);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new Reply
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Expresion = reader["Expresion"].ToString(),
                            Resultado = Convert.ToDecimal(reader["Resultado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
