
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class MantenimientoService : IMantenimientoService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public MantenimientoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddMantenimiento(Mantenimiento mantenimiento)
        {
            bool resultado = _unidadDeTrabajo._mantenimientoDAL.Add(mantenimiento);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteMantenimiento(Mantenimiento mantenimiento)
        {
            bool resultado = _unidadDeTrabajo._mantenimientoDAL.Remove(mantenimiento);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Mantenimiento GetById(int id)
        {
            Mantenimiento mantenimiento;
            mantenimiento = _unidadDeTrabajo._mantenimientoDAL.Get(id);
            return mantenimiento;
        }

        public async Task<IEnumerable<Mantenimiento>> GetMantenimientosAsync()
        {
            IEnumerable<Mantenimiento> mantenimientos;
            mantenimientos = await _unidadDeTrabajo._mantenimientoDAL.GetAll();
            return mantenimientos;
        }

        public bool UpdateMantenimiento(Mantenimiento mantenimiento)
        {
            bool resultado = _unidadDeTrabajo._mantenimientoDAL.Update(mantenimiento);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
