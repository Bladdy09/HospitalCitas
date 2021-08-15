using System;
using System.Collections.Generic;

#nullable disable

namespace Citas.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Citas>();
        }

        public int Idpaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaDeLaCita { get; set; }

        public virtual ICollection<Citas> Cita { get; set; }
    }
}
