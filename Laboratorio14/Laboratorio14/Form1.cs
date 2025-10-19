using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Laboratorio14
{
    public partial class frmProductos : Form
    {
        // Variable de conexión accesible en todo el formulario
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=Productos;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        private SqlConnection conexion;
        private bool nuevo;

        public frmProductos()
        {
            InitializeComponent();
            conexion = new SqlConnection(connectionString);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;

            txtId.Enabled = false;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            tsbNuevo.Enabled = false;
            tsbGuardar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbEliminar.Enabled = false;

            txtId.Enabled = false;
            tsbBuscar.Enabled = false;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtNombre.Focus();
            nuevo = true;
        }

        private void tsbGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (nuevo)
                {
                    cmd.CommandText = "INSERT INTO Laptops (NOMBRE, PRECIO, STOCK) VALUES (@nombre, @precio, @stock)";
                }
                else
                {
                    cmd.CommandText = "UPDATE Laptops SET NOMBRE=@nombre, PRECIO=@precio, STOCK=@stock WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                }

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", Convert.ToSingle(txtStock.Text));

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show(nuevo ? "Registro ingresado correctamente!" : "Registro actualizado correctamente!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            LimpiarFormulario();
        }

        private void tsbCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Laptops WHERE Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registro eliminado correctamente!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            LimpiarFormulario();
        }

        private void tsbBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Laptops WHERE Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", tstId.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tsbNuevo.Enabled = false;
                    tsbGuardar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbEliminar.Enabled = true;
                    tstId.Enabled = false;

                    tsbBuscar.Enabled = false;
                    txtNombre.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtStock.Enabled = true;
                    txtNombre.Focus();

                    txtId.Text = reader["Id"].ToString();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtPrecio.Text = reader["Precio"].ToString();
                    txtStock.Text = reader["Stock"].ToString();
                    nuevo = false;
                }
                else
                {
                    MessageBox.Show("Ningún registro encontrado con el Id ingresado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
                tstId.Text = "";
            }

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;

            txtId.Enabled = true;
            tstId.Enabled = true;  // habilita el textbox de búsqueda
            tsbBuscar.Enabled = true;

            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
    }
}
