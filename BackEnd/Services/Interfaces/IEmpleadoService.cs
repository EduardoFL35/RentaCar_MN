using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetEmpleadosAsync();
        Empleado GetById(int id);
        bool AddEmpleado(Empleado empleado);
        bool UpdateEmpleado(Empleado empleado);
        bool DeleteEmpleado(Empleado empleado);
    }
}
