using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HospitalCitas.Models
{
    public partial class Secretaria
    {
        public Secretaria()
        {
            Cita = new HashSet<Cita>();
        }

        public int Idsecretaria { get; set; }
        [Required(ErrorMessage = "ingrese su Nombre")]

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Por favor ingresar su Cargo")]

        public string Cargo { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Por favor ingresar su correo")]

        public string Correo { get; set; }
        [Required(ErrorMessage = "ingrese su contraseña")]

        public string Contrasena { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
