using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Application.Dtos;
using Financas.Domain;

namespace Financas.Application.Contracts
{
    public interface IParceladoService
    {
        Task<ParceladoDto> AddParcelado(ParceladoDto model);
        Task<ParceladoDto> UpdateParcelado(int id, ParceladoDto model);
        Task<bool> DeleteParcelado(int id);

        Task<ParceladoDto[]> GetAllParceladosAsync();
        Task<ParceladoDto[]> GetAllParceladosByNomeAsync(string nome);
        Task<ParceladoDto[]> GetAllParceladosByMesAsync(int mes, int ano);
        Task<ParceladoDto[]> GetAllParceladosByAnoAsync(int ano);
        Task<ParceladoDto[]> GetAllParceladosByCategoriaAsync(int categoriaId);
        Task<ParceladoDto> GetParceladoByIdAsync(int id);
    }
}