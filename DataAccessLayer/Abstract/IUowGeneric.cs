using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUowGeneric<T> where T:class
    {
        public void Add(T t);
        public void Delete(T t);
        public void Update(T t);
        public void Multipart(List<T> t);
        public T GetById(int id);
    }
}
