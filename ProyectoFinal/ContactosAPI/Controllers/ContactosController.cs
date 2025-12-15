// API REST del proyecto, aqui se manejan los metodos principales para el CRUD
// Puente de conexión entre la base de datos y la aplicación cliente
// Expone endpoints REST para que el cliente (webforms) pueda consumirlos via HTTP.
// Devuelve respuestas JSON y maneja errores adecuadamente.
using ContactosAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace ContactosAPI.Controllers
{
    [RoutePrefix("api/Contactos")]
    public class ContactosController : ApiController
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AgendaDB"].ConnectionString;

        // LISTAR
        [HttpGet]
        [Route("Listar")]
        public IHttpActionResult Listar()
        {
            try
            {
                List<Contacto> lista = new List<Contacto>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Contactos ORDER BY FechaRegistro ASC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Contacto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
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

        // INSERTAR
        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar(Contacto contacto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Contactos (Nombre, Telefono, Correo)
                                     VALUES (@Nombre, @Telefono, @Correo)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", contacto.Correo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return Ok("Contacto registrado correctamente");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // EDITAR
        [HttpPut]
        [Route("Editar")]
        public IHttpActionResult Editar(Contacto contacto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Contactos 
                                     SET Nombre=@Nombre, Telefono=@Telefono, Correo=@Correo
                                     WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", contacto.Id);
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", contacto.Correo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return Ok("Contacto actualizado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // ELIMINAR
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IHttpActionResult Eliminar(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Contactos WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return Ok("Contacto eliminado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // BUSCAR
        [HttpGet]
        [Route("Buscar")]
        public IHttpActionResult Buscar(string nombre)
        {
            try
            {
                List<Contacto> lista = new List<Contacto>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Contactos WHERE Nombre LIKE @Nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Contacto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
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


