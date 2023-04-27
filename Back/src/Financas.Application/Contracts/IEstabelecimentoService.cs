using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Application.Dtos;

namespace Financas.Application.Contracts
{
    public interface IEstabelecimentoService
    {
        Task<EstabelecimentoDto>AddEstabelecimento(EstabelecimentoDto model);
        Task<EstabelecimentoDto> UpdateEstabelecimento(int id, EstabelecimentoDto model);
        Task<bool> DeleteEstabelecimento(int id);

        Task<EstabelecimentoDto[]> GetAllEstabelecimentosAsync();
        Task<EstabelecimentoDto[]> GetAllEstabelecimentosByNomeAsync(string nome);
        Task<EstabelecimentoDto> GetEstabelecimentoByIdAsync(int id);
    }
}