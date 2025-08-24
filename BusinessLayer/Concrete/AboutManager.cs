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
    public class AboutManager : IAboutServices
    {
        private readonly IAbout _Iabout;

        public AboutManager(IAbout about)
        {
            _Iabout = about;
        }
        public void Add(About t)
        {
            _Iabout.Add(t);
        }

        public void Delete(About t)
        {
            _Iabout.Delete(t);
        }

        public About GetById(About t)
        {
            throw new NotImplementedException();
        }

       

        public List<About> list()
        {
            var gstr = _Iabout.list();

            return gstr;
        }

        public void Update(About t)
        {
            _Iabout.Update(t);
        }
    }
}
