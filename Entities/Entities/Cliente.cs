using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string DireccionUsuario { get; set; } = null!;

        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
