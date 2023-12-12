using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoriaHelper : ICategoriaHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public CategoriaHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public CategoriaViewModel AddCategoria(CategoriaViewModel categoriaViewModel)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            CategoriaViewModel categoria = new CategoriaViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Categoria", categoriaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);
            }

            return categoria;
        }

        public void DeleteCategoria(int id)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Categoria/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public CategoriaViewModel EditCategoria(CategoriaViewModel categoriaViewModel)
        {
            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            CategoriaViewModel categoria = new CategoriaViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Categoria", categoriaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);
            }

            return categoria;
        }

        public List<CategoriaViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<CategoriaViewModel> lista = new List<CategoriaViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Categoria");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(content);
            }

            return lista;
        }

        public CategoriaViewModel GetById(int id)
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            CategoriaViewModel categoria = new CategoriaViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Categoria/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);
            }

            return categoria;
        }
    }
}
