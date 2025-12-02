using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3
{
    public partial class Respuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRespuestas();
            }
        }

        private void CargarRespuestas()
        {
            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=CarolinaRodriguez;Integrated Security=True";


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Pregunta, Respuesta FROM CR_Respuestas", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                rptRespuestas.DataSource = dt;
                rptRespuestas.DataBind();
            }
        }
    }
}