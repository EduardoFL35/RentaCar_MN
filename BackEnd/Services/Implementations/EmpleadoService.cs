using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public EmpleadoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddEmpleado(Empleado empleado)
        {
            bool resultado = _unidadDeTrabajo._empleadoDAL.Add(empleado);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeleteEmpleado(Empleado empleado)
        {
            bool resultado = _unidadDeTrabajo._empleadoDAL.Remove(empleado);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Empleado GetById(int id)
        {
            Empleado empleado;
            empleado = _unidadDeTrabajo._empleadoDAL.Get(id);
            return empleado;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {
            IEnumerable<Empleado> empleados;
            empleados = await _unidadDeTrabajo._empleadoDAL.GetAll();
            return empleados;
        }

        public bool UpdateEmpleado(Empleado empleado)
        {
            bool resultado = _unidadDeTrabajo._empleadoDAL.Update(empleado);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}