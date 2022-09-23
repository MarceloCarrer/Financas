using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;
using Financas.Persistence.Context;
using Financas.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence
{
    public class CategoriaPersistence : ICategoriaPersistence
    {
        private readonly DataContext _context;

        public CategoriaPersistence(DataContext context)
        {
            _context = context;
        }

        //CATEGORIAS
        public async Task<Categoria[]> GetAllCategoriasAsync()
        {
            IQueryable<Categoria> query = _context.Categorias
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);

            query = query.AsNoTracking()
                         .OrderBy(ct => ct.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Categoria[]> GetAllCategoriasByNomeAsync(string nome)
        {
            IQueryable<Categoria> query = _context.Categorias
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);

            query = query.Where(ct => ct.Nome.ToLower().Contains(nome.ToLower()))
                         .AsNoTracking()
                         .OrderBy(ct => ct.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            IQueryable<Categoria> query = _context.Categorias
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);
                        
            query = query.Where(ct => ct.Id == id)
                         .AsNoTracking()
                         .OrderBy(ct => ct.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}