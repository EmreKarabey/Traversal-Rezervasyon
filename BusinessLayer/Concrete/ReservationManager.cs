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
    public class ReservationManager : IReservationServices
    {
        IReservation _ıreservation;

        public ReservationManager(IReservation reservation)
        {
            _ıreservation = reservation;
        }
        public void Add(Reservation t)
        {
            _ıreservation.Add(t);
        }

        public List<Reservation> ApprovalReservation(int id)
        {
            var gstr = _ıreservation.GetListFiltre(n => n.AppUserID == id).Where(N => N.Status == "Onay Bekleniyor").ToList();

            return gstr;
           
        }

        public void Delete(Reservation t)
        {
            throw new NotImplementedException();
        }

      

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> IncludeCurrentReservations(int id)
        {
            var gstr = _ıreservation.IncludeCurrentReservation(id);

            return gstr;
        }

        public List<Reservation> IncludeOldReservations(int id)
        {
            var gstr = _ıreservation.IncludeOldReservation(id);

            return gstr;
        }

        public List<Reservation> IncludeReservations(int id)
        {
            var gstr = _ıreservation.IncludeReservations(id);

            return gstr;
        }

        public List<Reservation> LastReservations(int id)
        {
           var gstr= _ıreservation.LastReservations(id);

            return gstr;
        }

        public List<Reservation> list()
        {
            throw new NotImplementedException();
        }

        public void Update(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
