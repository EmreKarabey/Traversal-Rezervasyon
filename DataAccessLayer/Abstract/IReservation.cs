using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IReservation:IGeneric<Reservation>
    {
        public List<Reservation> IncludeReservations(int id);
        public List<Reservation> IncludeCurrentReservation(int id);
        public List<Reservation> IncludeOldReservation(int id);
       
    }
}
