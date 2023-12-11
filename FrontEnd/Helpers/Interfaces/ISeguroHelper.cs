using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISeguroHelper
    {

        string Token { get; set; }
        List<SeguroViewModel> GetAll();
        SeguroViewModel GetById(int id);
        SeguroViewModel AddSeguro(SeguroViewModel seguroViewModel);
        SeguroViewModel EditSeguro(SeguroViewModel seguroViewModel);

        void DeleteSeguro(int id);

    }
}