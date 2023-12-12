using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class TransaccioneHelper : ITransaccioneHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public TransaccioneHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }


        public TransaccioneViewModel AddTransaccione(TransaccioneViewModel transaccioneViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            TransaccioneViewModel transaccione = new TransaccioneViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Transaccione", transaccioneViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transaccione = JsonConvert.DeserializeObject<TransaccioneViewModel>(content);
            }

            return transaccione;
        }

        public void DeleteTransaccione(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Transaccione/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public TransaccioneViewModel EditTransaccione(TransaccioneViewModel transaccioneViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            TransaccioneViewModel transaccione = new TransaccioneViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Transaccione", transaccioneViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transaccione = JsonConvert.DeserializeObject<TransaccioneViewModel>(content);
            }

            return transaccione;
        }

        public List<TransaccioneViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<TransaccioneViewModel> lista = new List<TransaccioneViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Transaccione");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<TransaccioneViewModel>>(content);
            }

            return lista;
        }

        public TransaccioneViewModel GetById(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            TransaccioneViewModel transaccione = new TransaccioneViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Transaccione/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transaccione = JsonConvert.DeserializeObject<TransaccioneViewModel>(content);
            }

            return transaccione;
        }
    }
}
