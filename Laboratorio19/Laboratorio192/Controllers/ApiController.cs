using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio192.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public async Task<ActionResult> Index()  // metodo asincrono (evita que se congele la aplicacion)
        {

            string url = "https://localhost:44333/api/values/get"; // URL de API que se esta consumiendo (Lab19-1) 

            HttpClient client = new HttpClient();   // crea un objeto HttpClient que sirve para hacer peticiones HTTP como GET, POST, PUT, DELETE. 

            var response = await client.GetStringAsync(url);  // Hace una peticion GET al API | await significa esperar a que el API responda, pero no congeles la pagina mientras tanto | response recibe el contenido que devuelve el API.

            ViewBag.Resultado = response; // la respuesta del API se guarda en ViewBag, para enviarla a la vista.

            return View();  // abre la vista MVC, el JSON recibido se mostrará en Index.cshtml
        }
    }
}