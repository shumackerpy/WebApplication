using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Models
{
    public partial class Asistencium
    {
        public int Id { get; set; }
        public int? IdAlumno { get; set; }     
        public int? IdCurso { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)] // Cambiar de DataType.DateTime a DataType.Date
        public DateTime? Fecha { get; set; }
        public bool? Estado { get; set; }

        [Display(Name = "Alumno")]
        public virtual Alumno? IdAlumnoNavigation { get; set; }

        [Display(Name = "Curso")]
        public virtual Curso? IdCursoNavigation { get; set; }
    }
}
