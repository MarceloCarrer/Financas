using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface ICategoriaPersistence
    {
        Task<Categoria[]> GetAllCategoriasAsync();
        Task<Categoria[]> GetAllCategoriasByNomeAsync(string nome);
        Task<Categoria> GetCategoriaByIdAsync(int id);
    }

}