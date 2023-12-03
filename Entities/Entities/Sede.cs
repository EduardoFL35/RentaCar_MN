using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Sede
    {
        public Sede()
        {
            Automoviles = new HashSet<Automovile>();
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string NombreUbi { get; set; } = null!;
        public string? Provincia { get; set; }
        public string Ciudad { get; set; } = null!;
        public string DireccionSede { get; set; } = null!;

        public virtual ICollection<Automovile> Automoviles { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
