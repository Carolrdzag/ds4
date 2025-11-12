using Microsoft.Data.SqlClient; // Importa el espacio de nombres para SQL Server
using System; // Importa el espacio de nombres para clases básicas
using System.Data;
using System.Linq; // Importa el espacio de nombres para LINQ
using System.Text.RegularExpressions; // Importa el espacio de nombres para expresiones regulares
using System.Windows.Forms; // Importa el espacio de nombres para formularios de Windows

namespace Parcial2
{
    public partial class Form1 : Form
    {
        // Conexión SQL
        private SqlConnection conexion;
        string connectionString = @"Server=.\SQLEXPRESS02;Database=ConversorDB;Trusted_Connection=True;Encrypt=False;";

        public Form1()
        {
            InitializeComponent();
            conexion = new SqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // BOTÓN: Libras a Kilogramos
        private void btnLk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtlbs.Text))
                {
                    MessageBox.Show("Ingrese un valor en libras.");
                    return;
                }

                double libras = Convert.ToDouble(txtlbs.Text);
                double kilogramos = Calculos.LibrasAKilogramos(libras);

                txtkg.Text = kilogramos.ToString("F4");

                // Guardar en base de datos
                GuardarConversionEnBD("Libras a Kilogramos", libras, kilogramos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conversión: " + ex.Message);
            }
        }

        // BOTÓN: Kilogramos a Libras
        private void btnKl_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtkg.Text))
                {
                    MessageBox.Show("Ingrese un valor en kilogramos.");
                    return;
                }

                double kilogramos = Convert.ToDouble(txtkg.Text);
                double libras = Calculos.KilogramosALibras(kilogramos);

                txtlbs2.Text = libras.ToString("F4");

                // Guardar en base de datos
                GuardarConversionEnBD("Kilogramos a Libras", kilogramos, libras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conversión: " + ex.Message);
            }
        }

        // BOTÓN: Mostrar historial desde la base de datos
        private void btnMostrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();

                string query = "SELECT TipoConversion, ValorEntrada, ValorSalida, Fecha FROM HistorialConversiones ORDER BY Fecha DESC";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string tipo = reader["TipoConversion"].ToString();
                        double entrada = Convert.ToDouble(reader["ValorEntrada"]);
                        double salida = Convert.ToDouble(reader["ValorSalida"]);
                        DateTime fecha = Convert.ToDateTime(reader["Fecha"]);

                        string linea = $"{fecha:dd/MM/yyyy HH:mm} → {tipo}: {entrada} = {salida}";
                        listBox1.Items.Add(linea);
                    }

                    reader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar historial: " + ex.Message);
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        // BOTÓN: Limpiar campos y lista
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtlbs.Clear();
            txtlbs2.Clear();
            txtkg.Clear();
            txtkg2.Clear();
            listBox1.Items.Clear();
        }

        // MÉTODO: Guardar cada conversión en la base de datos
        private void GuardarConversionEnBD(string tipo, double valorEntrada, double valorSalida)
        {
            try
            {
                string query = "INSERT INTO HistorialConversiones (TipoConversion, ValorEntrada, ValorSalida, Fecha) VALUES (@tipo, @entrada, @salida, @fecha)";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@entrada", valorEntrada);
                    cmd.Parameters.AddWithValue("@salida", valorSalida);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

    }

}


