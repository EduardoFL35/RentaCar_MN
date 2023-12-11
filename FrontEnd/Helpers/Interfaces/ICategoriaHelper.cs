using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoriaHelper
    {

        string Token { get; set; }
        List<CategoriaViewModel> GetAll();
        CategoriaViewModel GetById(int id);
        CategoriaViewModel AddCategoria(CategoriaViewModel categoriaViewModel);
        CategoriaViewModel EditCategoria(CategoriaViewModel categoriaViewModel);

        void DeleteCategoria(int id);

    }
}