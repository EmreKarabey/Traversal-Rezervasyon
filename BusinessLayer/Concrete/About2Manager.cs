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
    public class About2Manager : IAbout2Services
    {
        private readonly IAbout2 _about2;

        public About2Manager(IAbout2 about2)
        {
            _about2 = about2;
        }
        public void Add(About2 t)
        {
            _about2.Add(t);
        }

        public void Delete(About2 t)
        {
            _about2.Delete(t);
        }

        public About2 GetById(About2 t)
        {
            throw new NotImplementedException();
        }

        public List<About2> list()
        {
           var gstr = _about2.list();

            return gstr;
        }

        public void Update(About2 t)
        {
            _about2.Update(t);
        }
    }
}
