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
        //ToDo Inject DataBase 
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<T> GetAll()
        {
            throw new NotImplementedException();
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
