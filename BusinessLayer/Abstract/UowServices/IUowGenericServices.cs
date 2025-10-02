using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract.UowServices
{
    public interface IUowGenericServices<T>
    {
        public void Add(T t);
        public void Delete(T t);
        public void Update(T t);

        public T GetById(int id);
        public void Multipart(List<T> t);
    }
}
