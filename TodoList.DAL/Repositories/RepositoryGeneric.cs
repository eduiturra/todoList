using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.DAL.Repositories
{
    public class RepositoryGeneric<T> : IRespositoryGeneric<T> where T : class
    {
        protected readonly ApplicationDbContext Context;

        public RepositoryGeneric(ApplicationDbContext context)
        {
            Context = context;
        }

        public T Get(int? id)
        {
            return Context.Set<T>().Find(id);
        }

        public T GetCodigo(string id)
        {
            return Context.Set<T>().Find(id);
        }
        public T GetGuid(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return Context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> FindByAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> FindBySingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return await Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {

            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {

            Context.Set<T>().AddRange(entities);
        }


        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {

            Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;

        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
