using System.Threading.Tasks;
using Financas.Persistence.Context;
using Financas.Repository.Contract;

namespace Financas.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly DataContext _context;

        public GeralPersistence(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        

        public async Task<bool> SaveChengesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}