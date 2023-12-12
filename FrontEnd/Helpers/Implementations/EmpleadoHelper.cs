using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class EmpleadoHelper : IEmpleadoHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public EmpleadoHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public EmpleadoViewModel AddEmpleado(EmpleadoViewModel empleadoViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            EmpleadoViewModel empleado = new EmpleadoViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Empleado", empleadoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            }

            return empleado;
        }

        public void DeleteEmpleado(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Empleado/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public EmpleadoViewModel EditEmpleado(EmpleadoViewModel empleadoViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            EmpleadoViewModel empleado = new EmpleadoViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Empleado", empleadoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            }

            return empleado;
        }

        public List<EmpleadoViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Empleado");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(content);
            }

            return lista;
        }

        public EmpleadoViewModel GetById(int id)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            EmpleadoViewModel empleado = new EmpleadoViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Empleado/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            }

            return empleado;
        }
    }
}