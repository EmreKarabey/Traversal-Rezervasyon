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
    public class AnnouncementManager : IAnnouncementServices
    {
        IAnnouncement _announcement;

        public AnnouncementManager(IAnnouncement announcement)
        {
            _announcement = announcement;
        }
        public void Add(Announcement t)
        {
            _announcement.Add(t);
        }

        public void Delete(Announcement t)
        {
            var c = _announcement.GetById(t.AnnouncementID);

            _announcement.Delete(c);
        }

        public Announcement GetById(int id)
        {
            var gstr = _announcement.GetById(id);

            return gstr;
        }

        public List<Announcement> list()
        {
            var gstr = _announcement.list();

            return gstr;
        }

        public void Update(Announcement t)
        {
           

            _announcement.Update(t);
        }
    }
}
