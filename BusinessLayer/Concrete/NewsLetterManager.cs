using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterServices
    {
        private readonly INewsLetter _INewsLetter;
        public NewsLetterManager(INewsLetter newsLetter)
        {
            _INewsLetter = newsLetter;
        }
        public void Add(NewsLetter t)
        {
            _INewsLetter.Add(t);
        }

        public void Delete(NewsLetter t)
        {
            _INewsLetter.Update(t);
        }

      

        public NewsLetter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> list()
        {
            var gstr = _INewsLetter.list();

            return gstr;
        }

        public void Update(NewsLetter t)
        {
            _INewsLetter.Update(t);
        }
    }
}
