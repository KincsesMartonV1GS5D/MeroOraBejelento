using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // 86
        // T - Company  
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        IEnumerable<T> GetAll(string? includeProperties = null);
        
        //Meg lehet oldani egyszerübben.
        //IEnumerable<T> Get1All(Expression<Func<T, bool>> filter, string? includeProperties = null);

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
