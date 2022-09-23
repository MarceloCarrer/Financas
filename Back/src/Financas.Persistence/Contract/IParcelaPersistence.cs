using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface IParcelaPersistence
    {
        //PARCELAS
        Task<Parcela[]> GetAllParcelasAsync();
        Task<Parcela[]> GetAllParcelasByParceladosAsync(Parcelado ParceladoId);
        Task<Parcela> GetParcelasByIdAsync(int id);
    }

}