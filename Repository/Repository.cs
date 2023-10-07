using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Context;
using RestApiTemplate.Models;

namespace RestApiTemplate.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        public T Get(int id)
        {
            return Entities.Find(id);
        }
        public async void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException();
                Entities.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException();
                Entities.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Delete(int id)
        {
            try
            {
                var entity = await Entities.FindAsync(id);
                if (entity == null)
                    throw new ArgumentNullException();
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual IQueryable<T> GetAll()
        {
            return Entities;
        }
    }
}