using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPerimetro_Click_1(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtLadoA.Text);
                double b = double.Parse(txtLadoB.Text);
                double c = double.Parse(txtLadoC.Text);

                double s = (a + b + c) / 2;
                txtSemiperimetro.Text = s.ToString("0.00");

            }
            catch
            {
                MessageBox.Show("Por favor ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnArea_Click_1(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtLadoA.Text);
                double b = double.Parse(txtLadoB.Text);
                double c = double.Parse(txtLadoC.Text);

                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                txtArea.Text = area.ToString("0.00");
            }
            catch
            {
                MessageBox.Show("Verifique que los lados formen un triángulo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLadoA.Clear();
            txtLadoB.Clear();
            txtLadoC.Clear();
            txtSemiperimetro.Clear();
            txtArea.Clear();
            txtLadoA.Focus();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
  
    }
}
