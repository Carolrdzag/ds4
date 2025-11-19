using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio193.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api | usamos ActionResult porque es un controlador MVC e indica que devolvera una vista, JSON, Redirección, etc.
        public async Task<ActionResult> Index()  // metodo asincrono (evita que se congele la aplicacion) | Task<ActionResult> tipo de dato que regresa el metodo ( se usa task porque es asincrono) y se completara despues.
        {
            string url = "https://localhost:44333/api/values/get/2";
            

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);

            ViewBag.Resultado = response;

            return View();
        }
    }
}