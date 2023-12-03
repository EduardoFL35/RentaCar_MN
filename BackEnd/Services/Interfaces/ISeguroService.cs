using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISeguroService
    {
        Task<IEnumerable<Seguro>> GetSegurosAsync();
        Seguro GetById(int id);
        bool AddSeguro(Seguro seguro);
        //bool AddSeguro(Seguro seguro);
        bool UpdateSeguro(Seguro seguro);
        bool DeleteSeguro(Seguro seguro);
    }
}
