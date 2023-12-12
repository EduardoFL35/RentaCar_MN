using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class AutomovileHelper : IAutomovileHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public AutomovileHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public AutomovileViewModel AddAutomovile(AutomovileViewModel AutomovileViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            AutomovileViewModel automovile = new AutomovileViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Automovil", AutomovileViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                automovile = JsonConvert.DeserializeObject<AutomovileViewModel>(content);
            }

            return automovile;
        }

        public void DeleteAutomovile(int id)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Automovil/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public AutomovileViewModel EditAutomovile(AutomovileViewModel AutomovileViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            AutomovileViewModel automovile = new AutomovileViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Automovil", AutomovileViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                automovile = JsonConvert.DeserializeObject<AutomovileViewModel>(content);
            }

            return automovile;
        }

        public List<AutomovileViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<AutomovileViewModel> lista = new List<AutomovileViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Automovil");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<AutomovileViewModel>>(content);
            }

            return lista;
        }

        public AutomovileViewModel GetById(int id)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            AutomovileViewModel automovile = new AutomovileViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Automovil/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                automovile = JsonConvert.DeserializeObject<AutomovileViewModel>(content);
            }

            return automovile;
        }
    }
}
