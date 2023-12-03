using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Categoria GetById(int id);
        bool AddCategoria(Categoria categoria);
        bool UpdateCategoria(Categoria categoria);
        bool DeleteCategoria(Categoria categoria);
    }
}
