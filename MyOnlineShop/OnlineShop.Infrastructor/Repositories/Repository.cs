using OnlineShop.Infrastructor.DataBase;
using OnlineShop.Infrastructor.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineShopContext db;

        public Repository(OnlineShopContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            return await db.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
        public Task<T> GetByIdAsync(object id)
        {
            return Task.FromResult(db.Set<T>().Find(id));
        }

        public Task<int> UpdateAsync(T entity)
        {
            db.Set<T>().Update(entity);
            return db.SaveChangesAsync();
        }
    }
}
