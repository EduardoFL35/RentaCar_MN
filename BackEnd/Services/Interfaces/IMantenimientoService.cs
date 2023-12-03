using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IMantenimientoService
    {
        Task<IEnumerable<Mantenimiento>> GetMantenimientosAsync();
        Mantenimiento GetById(int id);
        bool AddMantenimiento(Mantenimiento mantenimiento);
        bool UpdateMantenimiento(Mantenimiento mantenimiento);
        bool DeleteMantenimiento(Mantenimiento mantenimiento);
    }
}
