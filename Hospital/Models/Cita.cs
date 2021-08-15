using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HospitalCitas.Models
{
    public partial class Cita
    {
        //[Key]
        public int Idcita { get; set; }


        public DateTime? FechaInicio { get; set; }


        public DateTime? FechaFinal { get; set; }
        [Required(ErrorMessage = "ingrese el nombre del paciente")]



        public int? Idpaciente { get; set; }
        [Required(ErrorMessage = "ingrese la secretaria que lo registro")]

        public int? Idsecretaria { get; set; }
        [Required(ErrorMessage = "ingrese el doctor que realizo la cita ")]

        public int? Iddoctor { get; set; }
        [Required(ErrorMessage = "ingrese si esta Finalizada,Sin iniciar o Cancelada")]

        public string EstadoDeLaCita { get; set; }
        public string Notas { get; set; }
        [Required(ErrorMessage = "Si o No")]

        public string CitaCompletada { get; set; }
        public DateTime? DuracionDeLaCita { get; set; }

        public virtual Doctor IddoctorNavigation { get; set; }
        public virtual Paciente IdpacienteNavigation { get; set; }
        public virtual Secretaria IdsecretariaNavigation { get; set; }
    }
}
