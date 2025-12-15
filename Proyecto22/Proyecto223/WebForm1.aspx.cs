using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

// puente entre el API y la pagina Web

namespace Proyecto223
{
    public partial class WebForm1 : Page
    {
        // URL base de la API donde corre
        private const string API_BASE_URL = "https://localhost:44354/api/Calculos/";

        protected void Page_Load(object sender, EventArgs e) // se ejecuta cada vez que se carga la pagina 
        {
            if (!IsPostBack)  // evita que se vuelvan a registrar eventos cuando se carga la pagina
            {
                // Registrar eventos de los botones, asignan qué método se ejecuta cuando el usuario hace clic.
                btnSumas.Click += btnSumas_Click;
                btnRestas.Click += btnRestas_Click;
                btnMultiplicaciones.Click += btnMultiplicaciones_Click;
                btnDivisiones.Click += btnDivisiones_Click;
                btnTodos.Click += btnTodos_Click;
            }
        }

        // eventos de los botones y llamado al metodo principal con su endpoint
        protected async void btnSumas_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerSumas");
        }

        protected async void btnRestas_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerRestas");
        }

        protected async void btnMultiplicaciones_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerMultiplicaciones");
        }

        protected async void btnDivisiones_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerDivisiones");
        }

        protected async void btnTodos_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerTodos");
        }

        protected async void btnRecientes_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerCalculosRecientes");
        }

        private async Task CargarDatos(string endpoint)  // metodo principal que llama a la API
        {
            try
            {
                ListBox1.Items.Clear();                 // limpia los datos 
                ListBox1.Items.Add("Cargando...");

                using (HttpClient client = new HttpClient())      
                {
                    // Configurar el cliente HTTP
                    client.BaseAddress = new Uri(API_BASE_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Llamar al API y hace la petición GET
                    HttpResponseMessage response = await client.GetAsync(endpoint);   

                    ListBox1.Items.Clear();

                    if (response.IsSuccessStatusCode)  // Verifica que la API respondio bien
                    {
                        // Leer la respuesta
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Convierte el JSON en una lista de objetos calculos
                        List<Calculo> calculos = JsonConvert.DeserializeObject<List<Calculo>>(jsonResponse);

                        // Mostrar en el ListBox
                        if (calculos != null && calculos.Count > 0)
                        {
                            foreach (var calculo in calculos)  // muestra los calculos
                            {
                                // lee cada calculo
                                string item = $"ID: {calculo.Id} | {calculo.Expresion} = {calculo.Resultado} | {calculo.Fecha:dd/MM/yyyy HH:mm}";
                                ListBox1.Items.Add(item);
                            }
                        }
                        else
                        {
                            ListBox1.Items.Add("No se encontraron resultados");
                        }
                    }
                    else
                    {
                        ListBox1.Items.Add($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add("Error de conexión con el API");
                ListBox1.Items.Add("Asegúrate de que el Web API esté ejecutándose");
                ListBox1.Items.Add($"Detalle: {ex.Message}");
            }
            catch (Exception ex)
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add($"Error: {ex.Message}");
            }
        }

        
    }

    // Clase modelo para deserializar la respuesta
    public class Calculo
    {
        public int Id { get; set; }
        public string Expresion { get; set; }
        public decimal Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}