using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationServices
    {
        private readonly IDestination _IDestinationServices;

        public DestinationManager(IDestination destinationServices)
        {
            _IDestinationServices = destinationServices;
        }
        public void Add(Destination t)
        {
            _IDestinationServices.Add(t);
        }

        public void Delete(Destination t)
        {
            _IDestinationServices.Delete(t);
        }

        public Destination GetById(int id)
        {
            var gstr = _IDestinationServices.GetById(id);

            return gstr;
        }

        public List<Destination> list()
        {
            var gstr = _IDestinationServices.list();

            return gstr;
        }

        public void Update(Destination t)
        {
            _IDestinationServices.Update(t);
        }
    }
}
