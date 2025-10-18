using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;



namespace Laboratorio13
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

            SqlCommand comando = new SqlCommand("SELECT ProductName FROM Products", conexion);
            comando.CommandType = CommandType.Text;
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["ProductName"].ToString());
            }

            
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");



        }

    }
}
