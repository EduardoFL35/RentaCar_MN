using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ITransaccioneHelper
    {

        string Token { get; set; }
        List<TransaccioneViewModel> GetAll();
        TransaccioneViewModel GetById(int id);
        TransaccioneViewModel AddTransaccione(TransaccioneViewModel transaccioneViewModel);
        TransaccioneViewModel EditTransaccione(TransaccioneViewModel transaccioneViewModel);

        void DeleteTransaccione(int id);

    }
}
