using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Automovile
    {
        public Automovile()
        {
            Mantenimientos = new HashSet<Mantenimiento>();
            Transacciones = new HashSet<Transaccione>();
        }

        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Anio { get; set; }
        public string Placa { get; set; } = null!;
        public int Disponibilidad { get; set; }
        public int Precio { get; set; }
        public DateTime FechaActualizado { get; set; }
        public int IdCategorias { get; set; }
        public int IdDeSedes { get; set; }
        public int IdSeguros { get; set; }

        public virtual Categoria IdCategoriasNavigation { get; set; } = null!;
        public virtual Sede IdDeSedesNavigation { get; set; } = null!;
        public virtual Seguro IdSegurosNavigation { get; set; } = null!;
        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
