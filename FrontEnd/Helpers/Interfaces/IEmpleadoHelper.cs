using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IEmpleadoHelper
    {

        string Token { get; set; }
        List<EmpleadoViewModel> GetAll();
        EmpleadoViewModel GetById(int id);
        EmpleadoViewModel AddEmpleado(EmpleadoViewModel empleadoViewModel);
        EmpleadoViewModel EditEmpleado(EmpleadoViewModel empleadoViewModel);

        void DeleteEmpleado(int id);

    }
}