using CRUD_de_medicos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace CRUD_de_medicos.Models
{
    public class Medico
    {
        public int pkMedicoID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo debe contener letras")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo debe contener letras")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }


        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo debe contener letras")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Cedula Profesional")]
        public string CedulaProfesional { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "ID Especialidad")]
        public int fkEspecialidadID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Creado Por")]
        public int CrBy { get; set; }

        [Display(Name = "Eliminado Por")]
        public string DltBy { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime CrDt { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de Eliminacion")]
        public DateTime FechaEliminacion { get; set; }


    }
}
