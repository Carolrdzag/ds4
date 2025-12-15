// Es el cliente HTTP de la aplicación
// Consume la API REST para realizar operaciones CRUD sobre los contactos.
// Usando estra clase se comunica con los endpoints definidos en ContactosController.cs.
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ContactosWeb.Models;

namespace ContactosWeb.Services
{
    public class ContactosService
    {
        private string baseUrl = "https://localhost:44340/api/Contactos/";

        // LISTAR
        public async Task<List<Contacto>> ObtenerContactos()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + "Listar");
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Contacto>>(json);
            }
        }

        // INSERTAR
        public async Task<string> RegistrarContacto(Contacto c)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(baseUrl + "Insertar", c);
                return await response.Content.ReadAsStringAsync();
            }
        }

        // EDITAR
        public async Task<string> ActualizarContacto(Contacto c)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync(baseUrl + "Editar", c);
                return await response.Content.ReadAsStringAsync();
            }
        }

        // ELIMINAR
        public async Task<string> EliminarContacto(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(baseUrl + "Eliminar/" + id);
                return await response.Content.ReadAsStringAsync();
            }
        }

        // BUSCAR
        public async Task<List<Contacto>> BuscarContacto(string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + "Buscar?nombre=" + nombre);
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Contacto>>(json);
            }
        }
    }
}
