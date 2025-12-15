// Esta clase representa los datos que se envían o reciben en endpoints
// como GET /contactos, POST /contactos, etc.

using System;


namespace ContactosAPI.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}