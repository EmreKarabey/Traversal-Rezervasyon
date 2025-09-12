using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IReservationServices:IGenericServices<Reservation>
    {
        
        public List<Reservation> ApprovalReservation(int id);
        public List<Reservation> IncludeReservations(int id);
        public List<Reservation> IncludeCurrentReservations(int id);
        public List<Reservation> IncludeOldReservations(int id);

        public List<Reservation> LastReservations(int id);

    }
}
