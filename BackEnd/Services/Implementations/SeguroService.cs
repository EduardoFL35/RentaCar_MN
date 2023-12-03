using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class SeguroService : ISeguroService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SeguroService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddSeguro(Seguro seguro)
        {
            bool resultado = _unidadDeTrabajo._seguroDAL.Add(seguro);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteSeguro(Seguro seguro)
        {
            bool resultado = _unidadDeTrabajo._seguroDAL.Remove(seguro);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Seguro GetById(int id)
        {
            Seguro seguro;
            seguro = _unidadDeTrabajo._seguroDAL.Get(id);
            return seguro;
        }

        public async Task<IEnumerable<Seguro>> GetSegurosAsync()
        {
            IEnumerable<Seguro> seguros;
            seguros = await _unidadDeTrabajo._seguroDAL.GetAll();
            return seguros;
        }

        public bool UpdateSeguro(Seguro seguro)
        {
            bool resultado = _unidadDeTrabajo._seguroDAL.Update(seguro);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
