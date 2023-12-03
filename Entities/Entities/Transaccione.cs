using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Transaccione
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int CostoTotal { get; set; }
        public string Detalles { get; set; } = null!;
        public DateTime ShipmentDate { get; set; }
        public int IdAutomovil { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Automovile IdAutomovilNavigation { get; set; } = null!;
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
    }
}
