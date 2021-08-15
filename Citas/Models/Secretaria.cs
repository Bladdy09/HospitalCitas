using System;
using System.Collections.Generic;

#nullable disable

namespace Citas.Models
{
    public partial class Secretaria
    {
        public Secretaria()
        {
            Cita = new HashSet<Citas>();
        }

        public int Idsecretaria { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public virtual ICollection<Citas> Cita { get; set; }
    }
}
