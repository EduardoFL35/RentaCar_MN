using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoriaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddCategoria(Categoria categoria)
        {
            bool resultado = _unidadDeTrabajo._categoriaDAL.Add(categoria);
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public bool DeleteCategoria(Categoria categoria)
        {
            bool resultado = _unidadDeTrabajo._categoriaDAL.Remove(categoria);  
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public Categoria GetById(int id)
        {
            Categoria categoria;
            categoria = _unidadDeTrabajo._categoriaDAL.Get(id);
            return categoria;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> categorias;
            categorias = await _unidadDeTrabajo._categoriaDAL.GetAll();   
            return categorias;
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            bool resultado = _unidadDeTrabajo._categoriaDAL.Update(categoria);  
            _unidadDeTrabajo.Complete();
            return resultado;
        }
    }
}
