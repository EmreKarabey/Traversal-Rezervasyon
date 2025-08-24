using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Feature2Manager : IFeature2Services
    {
        private readonly IFeature2Services _feature2Services;

        public Feature2Manager(IFeature2Services feature2Services)
        {
            _feature2Services = feature2Services;
        }
        public void Add(Feature2 t)
        {
            _feature2Services.Add(t);
        }

        public void Delete(Feature2 t)
        {
            _feature2Services.Delete(t);
        }

        public Feature2 GetById(Feature2 t)
        {
            throw new NotImplementedException();
        }

        public List<Feature2> list()
        {
            var gstr = _feature2Services.list();

            return gstr;
        }

        public void Update(Feature2 t)
        {
            _feature2Services.Update(t);
        }
    }
}
