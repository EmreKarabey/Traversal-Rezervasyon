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
    public class GuideManager : IGuideServices
    {
        private readonly IGuide _ıguide;

        public GuideManager(IGuide guide)
        {
            _ıguide = guide;
        }
        public void Add(Guide t)
        {
            _ıguide.Add(t);
        }

        public void Delete(Guide t)
        {
            _ıguide.Delete(t);
        }

        public Guide GetById(Guide t)
        {
            throw new NotImplementedException();
        }

        public List<Guide> list()
        {
            var gstr = _ıguide.list();

            return gstr;
        }

        public void Update(Guide t)
        {
            _ıguide.Update(t);
        }
    }
}
