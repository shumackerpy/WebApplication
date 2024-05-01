using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Models
{
    public partial class HistoricoCursosAlumno
    {
        public int Id { get; set; }

        [Display(Name = "Alumno")]
        public int? IdAlumno { get; set; }

        [Display(Name = "Curso")]
        public int? IdCurso { get; set; }

        [Display(Name = "Fecha de registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)] // Cambiar de DataType.DateTime a DataType.Date
        public DateTime? FechaRegistro { get; set; }

        [Display(Name = "Alumno")]
        public virtual Alumno? IdAlumnoNavigation { get; set; }

        [Display(Name = "Curso")]
        public virtual Curso? IdCursoNavigation { get; set; }
    }
}
