using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Feature1Manager : IFeature1Services
    {
        private readonly IFeature1 _feature1;
        public Feature1Manager(IFeature1 feature1)
        {
            _feature1 = feature1;
        }
        public void Add(Feature1 t)
        {
            _feature1.Add(t);
        }

        public void Delete(Feature1 t)
        {
            _feature1.Delete(t);
        }

  

        public Feature1 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature1> list()
        {
            var gstr = _feature1.list();

            return gstr;
        }

        public void Update(Feature1 t)
        {
            _feature1.Update(t);
        }
    }
}
