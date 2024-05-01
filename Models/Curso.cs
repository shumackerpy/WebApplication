using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Asistencia = new HashSet<Asistencium>();
            HistoricoCursosAlumnos = new HashSet<HistoricoCursosAlumno>();
        }
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }

        [Display(Name = "Titulo")]
        public string? TituloObtenido { get; set; }

        [Display(Name = "Horario")]
        public string? Horario { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)] // Cambiar de DataType.DateTime a DataType.Date
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Fecha de termino")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)] // Cambiar de DataType.DateTime a DataType.Date
        public DateTime? FechaTermino { get; set; }

        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<HistoricoCursosAlumno> HistoricoCursosAlumnos { get; set; }
        
    }
}
