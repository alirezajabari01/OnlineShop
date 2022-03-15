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

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
