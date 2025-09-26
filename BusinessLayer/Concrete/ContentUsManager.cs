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
    public class ContentUsManager : IContentUsServices
    {
        IContentUs _contentUs;
        public ContentUsManager(IContentUs contentUs)
        {
            _contentUs = contentUs;
        }
        public void Add(ContentUs t)
        {
            throw new NotImplementedException();
        }

        public void ChangeFalseContentUs(int id)
        {
             _contentUs.ChangeFalseContentUs(id);
        }

        public void ChangeTrueContentUs(int id)
        {
            _contentUs.ChangeTrueContentUs(id);
        }

        public void Delete(ContentUs t)
        {
            throw new NotImplementedException();
        }

        public List<ContentUs> FalseContentUsList()
        {
            var gstr = _contentUs.FalseContentUsList();

            return gstr;
        }

        public ContentUs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContentUs> list()
        {
            var gstr = _contentUs.list();

            return gstr;
        }

        public List<ContentUs> TrueContentUsList()
        {
            var gstr = _contentUs.TrueContentUsList();

            return gstr;
        }

        public void Update(ContentUs t)
        {
            throw new NotImplementedException();
        }
    }
}
