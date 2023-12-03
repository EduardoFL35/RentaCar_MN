using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Empleado
    {
        public Empleado()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }
        public int IdSede { get; set; }

        public virtual Sede IdSedeNavigation { get; set; } = null!;
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
