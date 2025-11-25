using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio203
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=Productos;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        private bool nuevo
        {
            get { return ViewState["nuevo"] != null ? (bool)ViewState["nuevo"] : false; }
            set { ViewState["nuevo"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigurarInicio();
            }
        }

        private void ConfigurarInicio()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            nuevo = true;

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtNombre.Focus();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = conexion.CreateCommand();

                if (nuevo)
                {
                    cmd.CommandText = "INSERT INTO Laptops (Nombre, Precio, Stock) VALUES (@n, @p, @s)";
                }
                else
                {
                    cmd.CommandText = "UPDATE Laptops SET Nombre=@n, Precio=@p, Stock=@s WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                }

                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@p", Convert.ToDecimal(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@s", Convert.ToSingle(txtStock.Text));

                cmd.ExecuteNonQuery();
            }

            ConfigurarInicio();
            Limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            ConfigurarInicio();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Laptops WHERE Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
            }

            Limpiar();
            ConfigurarInicio();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Laptops WHERE Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtPrecio.Text = reader["Precio"].ToString();
                    txtStock.Text = reader["Stock"].ToString();

                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtNombre.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtStock.Enabled = true;

                    nuevo = false;
                }
                else
                {
                    Response.Write("<script>alert('No existe un registro con ese ID');</script>");
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.google.com");
        }

        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
    }
}