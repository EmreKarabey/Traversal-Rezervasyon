using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Feature1Manager : IFeature1Services
    {
        private readonly IFeature1Services _IFeature1Services;
        public Feature1Manager(IFeature1Services feature1Services)
        {
            _IFeature1Services = feature1Services;
        }
        public void Add(Feature1 t)
        {
            _IFeature1Services.Add(t);
        }

        public void Delete(Feature1 t)
        {
            _IFeature1Services.Delete(t);
        }

  

        public Feature1 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature1> list()
        {
            var gstr = _IFeature1Services.list();

            return gstr;
        }

        public void Update(Feature1 t)
        {
            _IFeature1Services.Update(t);
        }
    }
}
