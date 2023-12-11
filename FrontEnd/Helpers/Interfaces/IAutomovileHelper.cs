using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IAutomovileHelper
    {

        string Token { get; set; }
        List<AutomovileViewModel> GetAll();
        AutomovileViewModel GetById(int id);
        AutomovileViewModel AddAutomovile(AutomovileViewModel automovileViewModel);
        AutomovileViewModel EditAutomovile(AutomovileViewModel automovileViewModel);

        void DeleteAutomovile(int id);

    }
}
