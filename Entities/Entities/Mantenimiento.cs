using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Mantenimiento
    {
        public int Id { get; set; }
        public string TipoMantenimiento { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public int Costo { get; set; }
        public string DescripcionMantenimiento { get; set; } = null!;
        public int Estado { get; set; }
        public DateTime FechaActualizado { get; set; }
        public int IdAutomovil { get; set; }

        public virtual Automovile IdAutomovilNavigation { get; set; } = null!;
    }
}
