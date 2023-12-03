using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Cliente GetById(int id);
        bool AddCliente(Cliente cliente);
        bool UpdateCliente(Cliente cliente);
        bool DeleteCliente(Cliente cliente);
    }
}
