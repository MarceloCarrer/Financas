using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;
using Financas.Persistence.Context;
using Financas.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence
{
    public class ParceladoPersistence : IParceladoPersistence
    {
        private readonly DataContext _context;

        public ParceladoPersistence(DataContext context)
        {
            _context = context;
        }

        //PARCELADOS
        public async Task<Parcelado[]> GetAllParceladosAsync()
        {
            IQueryable<Parcelado> query = _context.Parcelados
                        .Include(g => g.Categorias);

            query = query.AsNoTracking().OrderByDescending(pd => pd.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Parcelado[]> GetAllParceladosByNomeAsync(string nome)
        {
            IQueryable<Parcelado> query = _context.Parcelados
                        .Include(g => g.Categorias);

            query = query.Where(pd => pd.Nome.ToLower().Contains(nome.ToLower()))
                         .AsNoTracking()
                         .OrderByDescending(pd => pd.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Parcelado[]> GetAllParceladosByMesAsync(int mes, int ano)
        {
            IQueryable<Parcelado> query = _context.Parcelados
                        .Include(g => g.Categorias);
                        
            query = query.Where(pd => pd.DataCompra.Month == mes && pd.DataCompra.Year == ano) 
                         .AsNoTracking()
                         .OrderByDescending(pd => pd.DataCompra.Month)
                         .ThenByDescending(pd => pd.DataCompra.Year);

            return await query.ToArrayAsync();
        }

        public async Task<Parcelado[]> GetAllParceladosByAnoAsync(int ano)
        {
            IQueryable<Parcelado> query = _context.Parcelados
                        .Include(g => g.Categorias);
                        
            query = query.Where(pd => pd.DataCompra.Year == ano) 
                         .AsNoTracking()
                         .OrderByDescending(pd => pd.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Parcelado[]> GetAllParceladosByCategoriaAsync(int categoriaId)
        {
            IQueryable<Parcelado> query = _context.Parcelados
                        .Include(g => g.Categorias);
                        
            query = query.Where(pd => pd.CategoriaId == categoriaId) 
                         .AsNoTracking()
                         .OrderByDescending(pd => pd.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Parcelado> GetParceladoByIdAsync(int id)
        {
            IQueryable<Parcelado> query = _context.Parcelados
                        .Include(g => g.Categorias);
                        
            query = query.Where(pd => pd.Id == id)
                         .AsNoTracking()
                         .OrderBy(pd => pd.Id);

            return await query.FirstOrDefaultAsync();
        }  
    }
}