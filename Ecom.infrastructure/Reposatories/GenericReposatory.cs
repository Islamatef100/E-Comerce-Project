using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Reposatories
{
    public class GenericReposatory<T> : IGenericReposetory<T> where T : class
    {
        private readonly AppDBContext context;
       public GenericReposatory(AppDBContext _context)
        {
            context = _context;
        }
        public async Task Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var entities = await context.Set<T>().AsNoTracking().ToListAsync();
            return entities;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query =  context.Set<T>().Include(item);
            }
            var entities = await query.ToListAsync();
            return entities;
        }

        public async Task<T> GetById(int id) => await context.Set<T>().FindAsync(id);

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            foreach (var item in includes)
            {
                context.Set<T>().Include(item);
            }
            var entitiey = await context.Set<T>().FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
            entitiey = await context.Set<T>().FindAsync(id);
            return entitiey;
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
