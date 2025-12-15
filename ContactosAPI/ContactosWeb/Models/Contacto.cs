// Esta clase es el modelo de datos central.
// Representa un contacto en la aplicación.
// Cuando la API devuelve resultados los serializa usando esta clase.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactosWeb.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}