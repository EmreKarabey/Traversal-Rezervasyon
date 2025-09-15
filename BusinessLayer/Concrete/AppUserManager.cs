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
    public class AppUserManager : IAppUserServices
    {
        IAppUser _appUser;

        public AppUserManager(IAppUser appUser)
        {
            _appUser = appUser;
        }
        public void Add(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser t)
        {
            _appUser.Delete(t);
        }

        public AppUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> list()
        {
            var gstr = _appUser.list();

            return gstr;
        }

        public void Update(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
