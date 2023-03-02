using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Ecommercemvcapp.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase,new()
    {
        private readonly AppDbContext _context; 
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
            EntityEntry entityentry = _context.Entry<T>(entity);
            entityentry.State = EntityState.Deleted;
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include
             (includeProperties));
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include
             (includeProperties));
            return await query.FirstOrDefaultAsync(n => n.Id == id);    
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityentry = _context.Entry<T>(entity);
            entityentry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }
    }
}
