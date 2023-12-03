using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IAutomovilDAL _automovilDAL {  get; }
        ICategoriaDAL _categoriaDAL { get; }
        IClienteDAL _clienteDAL { get; }
        IEmpleadoDAL _empleadoDAL { get; }
        IMantenimientoDAL _mantenimientoDAL { get; }
        ISedeDAL _sedeDAL { get; }
        ISeguroDAL _seguroDAL { get; }
        ITransaccionDAL _transaccionDAL { get; }


        bool Complete();
    }
}
