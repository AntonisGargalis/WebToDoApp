using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebToDoApp.Areas.User.Data;
using WebToDoApp.Areas.User.Data.Repo.IRepo;

namespace WebToDoApp.Areas.User.Data.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> DbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            DbSet = _db.Set<T>();

        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            if (tracked)
            {
                IQueryable<T> query = DbSet;
                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties.Split(
                        new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
            else
            {
                IQueryable<T> query = DbSet.AsNoTracking();
                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties.Split(
                        new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRang(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
