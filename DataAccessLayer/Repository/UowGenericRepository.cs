using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class UowGenericRepository<T> : IUowGeneric<T> where T : class
    {
        private readonly Context _context;

        public UowGenericRepository(Context context)
        {
            _context = context;
        }
        public void Add(T t)
        {
            throw new NotImplementedException();
        }

        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            var gstr = _context.Set<T>().Find(id);

            return gstr;
        }

        public void Multipart(List<T> t)
        {
            _context.UpdateRange(t);
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
