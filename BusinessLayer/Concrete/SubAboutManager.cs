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
    public class SubAboutManager : ISubAboutServices
    {
        private readonly ISubAbout _ISubAbout;

        public SubAboutManager(ISubAbout subAbout)
        {
            _ISubAbout = subAbout;
        }
        public void Add(SubAbout t)
        {
            _ISubAbout.Add(t);
        }

        public void Delete(SubAbout t)
        {
            _ISubAbout.Delete(t);
        }

      

        public SubAbout GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> list()
        {
            var gstr = _ISubAbout.list();

            return gstr;
        }

        public void Update(SubAbout t)
        {
            _ISubAbout.Update(t);
        }
    }
}
