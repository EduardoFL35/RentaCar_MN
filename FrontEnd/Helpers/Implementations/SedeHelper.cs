using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SedeHelper : ISedeHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public SedeHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public SedeViewModel AddSede(SedeViewModel sedeViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            SedeViewModel sede = new SedeViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Sede", sedeViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                sede = JsonConvert.DeserializeObject<SedeViewModel>(content);
            }

            return sede;
        }

        public void DeleteSede(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Sede/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public SedeViewModel EditSede(SedeViewModel sedeViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            SedeViewModel sede = new SedeViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Sede", sedeViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                sede = JsonConvert.DeserializeObject<SedeViewModel>(content);
            }

            return sede;
        }

        public List<SedeViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<SedeViewModel> lista = new List<SedeViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Sede");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<SedeViewModel>>(content);
            }

            return lista;
        }

        public SedeViewModel GetById(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            SedeViewModel sede = new SedeViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Sede/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                sede = JsonConvert.DeserializeObject<SedeViewModel>(content);
            }

            return sede;
        }
    }
}
