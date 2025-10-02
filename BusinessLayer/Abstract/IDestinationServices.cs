using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{

    public interface IDestinationServices:IGenericServices<Destination>
    {
        public string SplitWord(int id);
        public string SubstringDescription(int id);

        public Destination IncludeDestination(int id);
     
    }
}
