using System.Threading.Tasks;
using Financas.Application.Dtos;

namespace Financas.Application.Contracts
{
    public interface IGastoService
    {
        Task<GastoDto>AddGasto(GastoDto model);
        Task<GastoDto> UpdateGasto(int id, GastoDto model);
        Task<bool> DeleteGasto(int id);

        Task<GastoDto[]> GetAllGastosAsync();
        Task<GastoDto[]> GetAllGastosByLocalAsync(string local);
        Task<GastoDto[]> GetAllGastosByMesAsync(int mes, int ano);
        Task<GastoDto[]> GetAllGastosByAnoAsync(int ano);
        Task<GastoDto[]> GetAllGastosByCategoriaAsync(int categoriaId);
        Task<GastoDto> GetGastoByIdAsync(int id);
    }
}