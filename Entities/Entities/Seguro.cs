using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Seguro
    {
        public Seguro()
        {
            Automoviles = new HashSet<Automovile>();
        }

        public int Id { get; set; }
        public string TipoSeguro { get; set; } = null!;
        public int CostoSeguro { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Automovile> Automoviles { get; set; }
    }
}
