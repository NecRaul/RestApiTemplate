using RestApiTemplate.Models;

namespace RestApiTemplate.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IQueryable<T> GetAll();
    }
}