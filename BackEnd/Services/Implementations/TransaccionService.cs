using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class TransaccionService : ITransaccionService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public TransaccionService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddTransaccion(Transaccione transaccion)
        {
            bool resultado = _unidadDeTrabajo._transaccionDAL.Add(transaccion);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteTransaccion(Transaccione transaccion)
        {
            bool resultado = _unidadDeTrabajo._transaccionDAL.Remove(transaccion);
            _unidadDeTrabajo.Complete();
            
            return resultado;
        }

        public Transaccione GetById(int id)
        {
            Transaccione transaccion;
            transaccion = _unidadDeTrabajo._transaccionDAL.Get(id);
            return transaccion;
        }

        public async Task<IEnumerable<Transaccione>> GetTransaccionesAsync()
        {
            IEnumerable<Transaccione> transacciones;
            transacciones = await _unidadDeTrabajo._transaccionDAL.GetAll();
            return transacciones;
        }

        public bool UpdateTransaccion(Transaccione transaccion)
        {
            bool resultado = _unidadDeTrabajo._transaccionDAL.Update(transaccion);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
