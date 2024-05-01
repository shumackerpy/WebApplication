using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Asistencia = new HashSet<Asistencium>();
            HistoricoCursosAlumnos = new HashSet<HistoricoCursosAlumno>();
        }

        public int Id { get; set; }

        [Display(Name = "Nombre completo")]
        public string? NombreCompleto { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }
        public string? Departamento { get; set; }
        public string? Telefono { get; set; }
        [Display(Name = "Codigo empleado")]
        public string? Num_empleado { get; set; }

        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<HistoricoCursosAlumno> HistoricoCursosAlumnos { get; set; }
    }
}
