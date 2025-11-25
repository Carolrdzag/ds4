using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio202
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int N;

            if (int.TryParse(txtN.Text, out N) && N > 0) // convierte a entero y verifica que N sea mayor que O.
            {
                string tabla = "<table border='1' cellpadding='5'>"; // construccion de la tabla 

                for (int i = 0; i < N; i++)  // recorre las filas
                {
                    tabla += "<tr>";  // abre una fila en HTML.
                    for (int j = 0; j < N; j++)  // recorre las columnas
                    {
                        // Condición de diagonal inversa
                        int valor = (i + j == N - 1) ? 1 : 0;  // operador ternario
                        tabla += $"<td>{valor}</td>";
                    }
                    tabla += "</tr>"; // Cuando termina el bucle j, se cierra la fila HTML.
                }

                tabla += "</table>"; // cierra la tabla antes de mostrarla 

                litMatriz.Text = tabla; // permite mostrar html directo en la pagina.
            }
            else
            {
                litMatriz.Text = "<span style='color:red;'>Ingrese un número válido.</span>"; // mensaje de error si la entrada no es valida.
            }
        }
    }
}