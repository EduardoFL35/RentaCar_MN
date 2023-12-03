using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISedeService
    {
        Task<IEnumerable<Sede>> GetSedesAsync();
        Sede GetById(int id);
        bool AddSede(Sede sede);
        bool UpdateSede(Sede sede);
        bool DeleteSede(Sede sede);
    }
}
