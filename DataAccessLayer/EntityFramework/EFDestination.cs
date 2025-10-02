using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestination : GenericRepository<Destination>, IDestination
    {
        public Destination IncludeDestination(int id)
        {
            using var c = new Context();

            var gstr = c.Destinations.Include(N=>N.Guide).Where(n=>n.DestinationID==id).FirstOrDefault();

            return gstr;
        }

        public string SplitWord(int id)
        {
            using var c = new Context();

            var s = c.Set<Destination>().Find(id);

            return s.Details1.Split(' ')[0].FirstOrDefault().ToString();
        }

        public string SubstringDescription(int id)
        {
            using var c = new Context();

            var gstr = c.Set<Destination>().Find(id);

            var nznzn = gstr.Details1.Substring(1).ToString();

            return nznzn;
        }
    }
}
