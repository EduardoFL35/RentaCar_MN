using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Automoviles = new HashSet<Automovile>();
        }

        public int Id { get; set; }
        public string DescripcionCategoria { get; set; } = null!;
        public string Licencia { get; set; } = null!;

        public virtual ICollection<Automovile> Automoviles { get; set; }
    }
}
