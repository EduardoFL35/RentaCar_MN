using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class MantenimientoHelper : IMantenimientoHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public MantenimientoHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public MantenimientoViewModel AddMantenimiento(MantenimientoViewModel mantenimientoViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            MantenimientoViewModel mantenimiento = new MantenimientoViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Mantenimiento", mantenimientoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                mantenimiento = JsonConvert.DeserializeObject<MantenimientoViewModel>(content);
            }

            return mantenimiento;
        }

        public void DeleteMantenimiento(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Mantenimiento/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public MantenimientoViewModel EditMantenimiento(MantenimientoViewModel mantenimientoViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            MantenimientoViewModel mantenimiento = new MantenimientoViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Mantenimiento", mantenimientoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                mantenimiento = JsonConvert.DeserializeObject<MantenimientoViewModel>(content);
            }

            return mantenimiento;
        }

        public List<MantenimientoViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<MantenimientoViewModel> lista = new List<MantenimientoViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Mantenimiento");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<MantenimientoViewModel>>(content);
            }

            return lista;
        }

        public MantenimientoViewModel GetById(int id)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            MantenimientoViewModel mantenimiento = new MantenimientoViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Mantenimiento/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                mantenimiento = JsonConvert.DeserializeObject<MantenimientoViewModel>(content);
            }

            return mantenimiento;
        }
    }
}