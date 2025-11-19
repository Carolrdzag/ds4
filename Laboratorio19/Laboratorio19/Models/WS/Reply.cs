using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

//Clase para manejar las respuestas del WS
namespace Laboratorio19.Models.WS
{
    public class Reply
    {
        public int result { get; set; }

        public object data { get; set; }
        public string message { get; set; }

    }
}
