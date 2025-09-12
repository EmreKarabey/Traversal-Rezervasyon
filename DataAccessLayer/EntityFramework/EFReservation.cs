using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservation : GenericRepository<Reservation>, IReservation
    {
        public List<Reservation> IncludeCurrentReservation(int id)
        {
            using var c = new Context();

            var gstr = c.Set<Reservation>().Include(N => N.Destination).Include(N => N.AppUser).Where(N => N.Status == "Onaylandı"&& N.AppUserID==id).ToList();

            return gstr;
        }

        public List<Reservation> IncludeOldReservation(int id)
        {
            using var c = new Context();

            var gstr = c.Set<Reservation>().Include(N => N.Destination).Include(N => N.AppUser).Where(N => N.Status == "Geçmiş Rezervasyon" && N.AppUserID == id).ToList();

            return gstr;
        }

        public List<Reservation> IncludeReservations(int id)
        {
            using var c = new Context();

            var gstr = c.Reservations.Include(N => N.Destination).Include(N => N.AppUser).Where(N => N.Status == "Onay Bekleniyor").Where(N => N.AppUserID == id).ToList();

            return gstr;
        }

        public List<Reservation> LastReservations(int id)
        {
            using var c = new Context();
            var gstr = c.Reservations.Include(n => n.AppUser).Where(N => N.AppUserID == id && N.Status == "Geçmiş Rezervasyon").ToList();

            return gstr;
        }
    }
}
