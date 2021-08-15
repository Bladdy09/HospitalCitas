using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Citas_B.Models
{
    public partial class Citas
    {
        public int Idcita { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? Idpaciente { get; set; }
        public int? Idsecretaria { get; set; }
        public int? Iddoctor { get; set; }
        public string EstadoDeLaCita { get; set; }
        public string Notas { get; set; }
        public string CitaCompletada { get; set; }
        public DateTime? DuracionDeLaCita { get; set; }

        public virtual Doctor IddoctorNavigation { get; set; }
        public virtual Paciente IdpacienteNavigation { get; set; }
        public virtual Secretaria IdsecretariaNavigation { get; set; }
    }
}
