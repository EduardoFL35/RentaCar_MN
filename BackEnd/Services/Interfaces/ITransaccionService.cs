using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ITransaccionService
    {
        Task<IEnumerable<Transaccione>> GetTransaccionesAsync();
        Transaccione GetById(int id);
        bool AddTransaccion(Transaccione transaccion);
        bool UpdateTransaccion(Transaccione transaccion);
        bool DeleteTransaccion(Transaccione transaccion);
    }
}
