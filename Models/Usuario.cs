using System;
using System.Collections.Generic;

namespace Aplicacion.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public bool? Restablecer { get; set; }
        public bool? Confirmado { get; set; }
        public string? Token { get; set; }
    }
}
