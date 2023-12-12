using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IClienteHelper
    {

        string Token { get; set; }
        List<ClienteViewModel> GetAll();
        ClienteViewModel GetById(int id);
        ClienteViewModel AddCliente(ClienteViewModel clienteViewModel);
        ClienteViewModel EditCliente(ClienteViewModel clienteViewModel);

        void DeleteCliente(int id);

    }
}
