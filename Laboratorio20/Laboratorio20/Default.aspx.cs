using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio20
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnGenerar_Click(object sender, EventArgs e)
        {  
            int n;
            if (int.TryParse(txtNumero.Text, out n))
            {
                string tabla = "<h3>Tabla del " + n + "</h3>";

                tabla += "<ul>";
                for (int i = 1; i <= 25; i++)
                {
                    tabla += $"<li>{n} × {i} = {n * i}</li>";
                }
                tabla += "</ul>";

                litTabla.Text = tabla;
            }
            else
            {
                litTabla.Text = "<span style='color:red;'>Ingrese un número válido.</span>";
            }
        }
    }
}