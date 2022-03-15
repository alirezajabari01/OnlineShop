using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(string id);   
        T Create(T entity);
        int Update(T entity);
    }
}
