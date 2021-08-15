using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HospitalCitas.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
        }

        public int Idpaciente { get; set; }
        [Required(ErrorMessage = "ingrese su Nombre")]

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Telefono { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su correo")]

        public string Correo { get; set; }
        public DateTime? FechaDeLaCita { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
