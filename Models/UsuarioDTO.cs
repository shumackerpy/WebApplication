﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Models
{
    //Modelo clase del login
    public class UsuarioDTO
    {
        public string? IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public string? ConfirmarClave { get; set; }
        public bool Restablecer { get; set; }
        public bool Confirmado { get; set; }
        public string? Token { get; set; }

    }
}
