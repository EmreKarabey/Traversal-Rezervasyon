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
            throw new NotImplementedException();
        }

        public void Delete(Announcement t)
        {
            throw new NotImplementedException();
        }

        public Announcement GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Announcement> list()
        {
            throw new NotImplementedException();
        }

        public void Update(Announcement t)
        {
            throw new NotImplementedException();
        }
    }
}
