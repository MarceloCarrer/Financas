using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface IEstabelecimentoPersistence
    {
        Task<Estabelecimento[]> GetAllEstabelecimentosAsync();
        Task<Estabelecimento[]> GetAllEstabelecimentosByNomeAsync(string nome);
        Task<Estabelecimento> GetEstabelecimentoByIdAsync(int id);
    }
}