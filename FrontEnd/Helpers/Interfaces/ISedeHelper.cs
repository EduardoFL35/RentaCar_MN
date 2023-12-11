using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISedeHelper
    {

        string Token { get; set; }
        List<SedeViewModel> GetAll();
        SedeViewModel GetById(int id);
        SedeViewModel AddSede(SedeViewModel sedeViewModel);
        SedeViewModel EditSede(SedeViewModel sedeViewModel);

        void DeleteSede(int id);

    }
}