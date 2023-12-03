using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IAutomovilDAL _automovilDAL { get; }
        public ICategoriaDAL _categoriaDAL { get; }
        public IClienteDAL _clienteDAL { get; }
        public IEmpleadoDAL _empleadoDAL { get; }
        public IMantenimientoDAL _mantenimientoDAL { get; }
        public ISedeDAL _sedeDAL { get; }
        public ISeguroDAL _seguroDAL { get; }
        public ITransaccionDAL _transaccionDAL { get; }

        private readonly RENTCARContext _context;

        public UnidadDeTrabajo(RENTCARContext context,
                                IAutomovilDAL automovilDAL,
                                ICategoriaDAL categoriaDAL,
                                IClienteDAL clienteDAl,
                                IEmpleadoDAL empleadoDAl,
                                IMantenimientoDAL mantenimientoDAl,
                                ISedeDAL sedeDAL,
                                ISeguroDAL seguroDAl,
                                ITransaccionDAL transaccionDAl)
        {
            _context = context;
            _automovilDAL = automovilDAL;
            _categoriaDAL = categoriaDAL;
            _clienteDAL = clienteDAl;
            _empleadoDAL = empleadoDAl;
            _mantenimientoDAL = mantenimientoDAl;
            _sedeDAL = sedeDAL;
            _seguroDAL = seguroDAl;
            _transaccionDAL = transaccionDAl;

        }
        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
