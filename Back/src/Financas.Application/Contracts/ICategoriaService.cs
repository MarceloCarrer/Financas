using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Application.Dtos;
using Financas.Domain;

namespace Financas.Application.Contracts
{
    public interface ICategoriaService
    {
        Task<CategoriaDto>AddCategoria(CategoriaDto model);
        Task<CategoriaDto> UpdateCategoria(int id, CategoriaDto model);
        Task<bool> DeleteCategoria(int id);

        Task<CategoriaDto[]> GetAllCategoriasAsync();
        Task<CategoriaDto[]> GetAllCategoriasByNomeAsync(string nome);
        Task<CategoriaDto> GetCategoriaByIdAsync(int id);
    }
}