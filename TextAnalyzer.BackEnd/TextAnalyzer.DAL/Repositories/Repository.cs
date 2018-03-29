using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.DAL.EF;
using TextAnalyzer.DAL.Interfaces;

namespace TextAnalyzer.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext db;
        public Repository(AppDbContext context)
        {
            this.db = context;
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public void Add(T item)
        {
            db.Set<T>().Add(item);
        }
        public void AddRange(IEnumerable<T> items)
        {
            db.Set<T>().AddRange(items);
        }
        public void Remove(T item)
        {
            db.Set<T>().Remove(item);
        }
        public void RemoveRange(IEnumerable<T> items)
        {
            db.Set<T>().RemoveRange(items);
        }
    }
}
