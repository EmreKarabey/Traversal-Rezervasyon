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

        public void Delete(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
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
