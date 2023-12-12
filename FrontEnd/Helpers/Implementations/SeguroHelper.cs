using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SeguroHelper : ISeguroHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public SeguroHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public SeguroViewModel AddSeguro(SeguroViewModel seguroViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            SeguroViewModel seguro = new SeguroViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Seguro", seguroViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                seguro = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            }

            return seguro;
        }

        public void DeleteSeguro(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Seguro/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public SeguroViewModel EditSeguro(SeguroViewModel seguroViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            SeguroViewModel seguro = new SeguroViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Seguro", seguroViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                seguro = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            }

            return seguro;
        }

        public List<SeguroViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<SeguroViewModel> lista = new List<SeguroViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Seguro");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<SeguroViewModel>>(content);
            }

            return lista;
        }

        public SeguroViewModel GetById(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            SeguroViewModel seguro = new SeguroViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Seguro/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                seguro = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            }

            return seguro;
        }
    }
}
