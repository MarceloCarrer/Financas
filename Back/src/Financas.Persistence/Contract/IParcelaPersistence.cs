using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface IParcelaPersistence
    {
        Task<Parcela[]> GetAllParcelasByParceladoIdAsync(int parceladoId);
        Task<Parcela> GetParcelaByIdsAsync(int parceladoId, int parcelaId);
    }

}