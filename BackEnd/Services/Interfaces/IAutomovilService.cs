using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IAutomovilService
    {
        Task<IEnumerable<Automovile>> GetAutomovilesAsync();
        Automovile GetById(int id);
        bool AddAutomovil(Automovile automovile);
        bool UpdateAutomovil(Automovile automovile);
        bool DeleteAutomovil(Automovile automovile);
    }
}
