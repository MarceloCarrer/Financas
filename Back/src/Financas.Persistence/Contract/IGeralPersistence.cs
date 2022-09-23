using System.Threading.Tasks;

namespace Financas.Repository.Contract
{
    public interface IGeralPersistence
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;

        Task<bool> SaveChengesAsync();
    }

}