using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        public void Add(T t)
        {
            using var c = new Context();

            c.Set<T>().Add(t);

            c.SaveChanges();
        }

        public void Delete(T t)
        {
            using var c = new Context();

            c.Set<T>().Remove(t);

            c.SaveChanges();
        }

        public List<T> list()
        {
           using var c = new Context();

            return c.Set<T>().ToList();
        }

        public void Update(T t)
        {
            using var c = new Context();

            c.Set<T>().Update(t);

            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Context();

            var gstr = c.Set<T>().Find(id);

            return gstr;
        }

        public List<T> GetListFiltre(Expression<Func<T,bool>> filtre)
        {
            using var c = new Context();

            var gstr = c.Set<T>().Where(filtre).ToList();

            return gstr;
        }
    }
}
