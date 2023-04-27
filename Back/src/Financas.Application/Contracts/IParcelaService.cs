using System.Threading.Tasks;
using Financas.Application.Dtos;

namespace Financas.Application.Contracts
{
    public interface IParcelaService
    {
        Task<ParcelaDto[]> SaveParcelas(int parceladoId, ParcelaDto[] models);
        Task<bool> DeletaParcelas(int parceladoId, int parcelaId);

        Task<ParcelaDto[]> GetAllParcelasByParceladoIdAsync(int parceladoId);
        Task<ParcelaDto> GetParcelaByIdsAsync(int parceladoId, int parcelaId);
    }
}