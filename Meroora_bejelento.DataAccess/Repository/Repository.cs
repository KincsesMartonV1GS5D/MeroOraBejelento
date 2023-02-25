using Meroora_bejelento.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // 87 2.rész
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.MeroOrak.Include(u => u.MeroOraTipus);
            this.dbSet = _db.Set<T>();
        }

        // 87 - jobbklikk implement from interface
        public void Add(T entity)
        {
            dbSet.Add(entity);
            //throw new NotImplementedException();
        }

        //includeProperties - "Berlo, Meroora"
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
            //throw new NotImplementedException();
        }


        //Meg lehet oldani egyszrübben
        //public IEnumerable<T> Get1All(Expression<Func<T, bool>> filter, string? includeProperties = null)
        //{
        //    IQueryable<T> query = dbSet;
        //    query = query.Where(filter);
        //    if (includeProperties != null)
        //    {
        //        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.ToList();
        //    //throw new NotImplementedException();
        //}


        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
            //throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            // throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            //throw new NotImplementedException();
        }



    }
}
