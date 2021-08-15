using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalCitas.Models
{
    public partial class WvcitasCancelar
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? Idpaciente { get; set; }
        public int? Idsecretaria { get; set; }
        public int? Iddoctor { get; set; }
        public string EstadoDeLaCita { get; set; }
        public string Notas { get; set; }
        public string CitaCompletada { get; set; }
        public DateTime? DuracionDeLaCita { get; set; }
    }
}
