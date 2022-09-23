using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface IParceladoPersistence
    {
        //PARCELADOS
        Task<Parcelado[]> GetAllParceladosAsync();
        Task<Parcelado[]> GetAllParceladosByNomeAsync(string nome);
        Task<Parcelado[]> GetAllParceladosByMesAsync(int mes, int ano);
        Task<Parcelado[]> GetAllParceladosByAnoAsync(int ano);
        Task<Parcelado[]> GetAllParceladosByCategoriaAsync(int categoriaId);
        Task<Parcelado> GetParceladoByIdAsync(int id);          
    }

}