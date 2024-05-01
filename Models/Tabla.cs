using System;
using System.Collections.Generic;

namespace Aplicacion.Models
{
    public partial class Tabla
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
