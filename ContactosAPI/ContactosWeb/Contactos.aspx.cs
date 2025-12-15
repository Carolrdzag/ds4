// Controla la logica de la pagina ASPX.
// El objeto ContactosService se encarga de consumir la API REST para realizar las operaciones CRUD.
// Captura los eventos de botones y del gridview.
// Realiza validaciones básicas antes de enviar datos a la API.
using ContactosWeb.Models;
using ContactosWeb.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactosWeb.Pages
{
    public partial class Contactos : System.Web.UI.Page
    {
        ContactosService service = new ContactosService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await CargarContactos();
            }
        }

        private async Task CargarContactos()
        {
            GridContactos.DataSource = await service.ObtenerContactos();
            GridContactos.DataBind();
        }

        // BUSCAR
        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            var lista = await service.BuscarContacto(txtBuscar.Text);
            GridContactos.DataSource = lista;
            GridContactos.DataBind();
        }

        protected async void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            await CargarContactos();
        }

        // SELECCIONAR PARA EDITAR
        protected void GridContactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Value = GridContactos.SelectedRow.Cells[0].Text;
            txtNombre.Text = GridContactos.SelectedRow.Cells[1].Text;
            txtTelefono.Text = GridContactos.SelectedRow.Cells[2].Text;
            txtCorreo.Text = GridContactos.SelectedRow.Cells[3].Text;
        }

        // GUARDAR
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            // valida que no queden campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                lblMensaje.Text = "Debe completar todos los campos.";
                return;
            }

            Contacto c = new Contacto
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            string mensaje = await service.RegistrarContacto(c);
            lblMensaje.Text = mensaje;
            await CargarContactos();
        }

        // ACTUALIZAR
        protected async void btnActualizar_Click(object sender, EventArgs e)
        {
            // valida que no queden campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                lblMensaje.Text = "Debe completar todos los campos.";
                return;
            }

            Contacto c = new Contacto
            {
                Id = int.Parse(txtId.Value),
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            string mensaje = await service.ActualizarContacto(c);
            lblMensaje.Text = mensaje;
            await CargarContactos();
        }

        // ELIMINAR
        protected async void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Value);

            string mensaje = await service.EliminarContacto(id);
            lblMensaje.Text = mensaje;
            await CargarContactos();
        }

        // LIMPIAR
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Value = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }

        // GENERAR PDF 
        protected void btnReportePdf_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // Título principal
                Paragraph titulo = new Paragraph("Agenda de Contactos", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph(" ")); // espacio

                // Crear tabla con 3 columnas (Nombre, Teléfono, Correo)
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100; // ocupa todo el ancho
                tabla.SetWidths(new float[] { 3f, 2f, 3f }); // proporción de columnas

                // Encabezados
                tabla.AddCell(new PdfPCell(new Phrase("Nombre", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Teléfono", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Correo", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Filas desde el GridView
                foreach (GridViewRow row in GridContactos.Rows)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(row.Cells[1].Text)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(row.Cells[2].Text)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(row.Cells[3].Text)) { HorizontalAlignment = Element.ALIGN_CENTER });
                }

                doc.Add(tabla);
                doc.Close();

                // Enviar el PDF al navegador como descarga
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteContactos.pdf");
                Response.OutputStream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                Response.Flush();
                Response.End();

            }

        }

    }
}

