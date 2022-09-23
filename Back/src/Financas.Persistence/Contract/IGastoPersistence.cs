using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface IGastoPersistence
    {
        //GASTOS
        Task<Gasto[]> GetAllGastosAsync();
        Task<Gasto[]> GetAllGastosByLocalAsync(string local);
        Task<Gasto[]> GetAllGastosByMesAsync(int mes, int ano);
        Task<Gasto[]> GetAllGastosByAnoAsync(int ano);
        Task<Gasto[]> GetAllGastosByCategoriaAsync(int categoriaId);
        Task<Gasto> GetGastoByIdAsync(int id);
    }

}