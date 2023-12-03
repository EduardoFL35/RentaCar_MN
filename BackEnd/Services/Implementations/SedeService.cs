using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SedeService : ISedeService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SedeService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddSede(Sede sede)
        {
            bool resultado = _unidadDeTrabajo._sedeDAL.Add(sede);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteSede(Sede sede)
        {
            bool resultado = _unidadDeTrabajo._sedeDAL.Remove(sede);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Sede GetById(int id)
        {
            Sede sede;
            sede = _unidadDeTrabajo._sedeDAL.Get(id);
            return sede;
        }

        public async Task<IEnumerable<Sede>> GetSedesAsync()
        {
            IEnumerable<Sede> sedes;
            sedes = await _unidadDeTrabajo._sedeDAL.GetAll();
            return sedes;
        }

        public bool UpdateSede(Sede sede)
        {
            bool resultado = _unidadDeTrabajo._sedeDAL.Update(sede);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
