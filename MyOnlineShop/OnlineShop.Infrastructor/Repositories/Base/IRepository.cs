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
        Task<T> GetByIdAsync(object id);   
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
    }
}
