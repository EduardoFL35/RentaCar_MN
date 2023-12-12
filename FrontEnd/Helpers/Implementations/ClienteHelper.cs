using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ClienteHelper : IClienteHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public ClienteHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public ClienteViewModel AddCliente(ClienteViewModel clienteViewModel)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Cliente", clienteViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);
            }

            return cliente;
        }

        public void DeleteCliente(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Cliente/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public ClienteViewModel EditCliente(ClienteViewModel clienteViewModel)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Cliente", clienteViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);
            }

            return cliente;
        }

        public List<ClienteViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Cliente");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ClienteViewModel>>(content);
            }

            return lista;
        }

        public ClienteViewModel GetById(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Cliente/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);
            }

            return cliente;
        }
    }
}
