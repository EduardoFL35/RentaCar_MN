using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ClienteService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddCliente(Cliente cliente)
        {
            bool resultado = _unidadDeTrabajo._clienteDAL.Add(cliente);
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public bool DeleteCliente(Cliente cliente)
        {
            bool resultado = _unidadDeTrabajo._clienteDAL.Remove(cliente);
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public Cliente GetById(int id)
        {
            Cliente cliente;
            cliente = _unidadDeTrabajo._clienteDAL.Get(id);
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            IEnumerable<Cliente> clientes;
            clientes = await _unidadDeTrabajo._clienteDAL.GetAll();
            return clientes;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            bool resultado = _unidadDeTrabajo._clienteDAL.Update(cliente);
            _unidadDeTrabajo.Complete();

            return resultado;

        }
    }
}
