using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IMantenimientoHelper
    {

        string Token { get; set; }
        List<MantenimientoViewModel> GetAll();
        MantenimientoViewModel GetById(int id);
        MantenimientoViewModel AddMantenimiento(MantenimientoViewModel mantenimientoViewModel);
        MantenimientoViewModel EditMantenimiento(MantenimientoViewModel mantenimientoViewModel);

        void DeleteMantenimiento(int id);

    }
}