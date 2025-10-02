using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract.UowServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete.UowManager
{
    public class UowAccountManager : IUowAccountServices
    {
        private readonly IAccount _account;

        private readonly IUowSave _uowSave;

        public UowAccountManager(IAccount account, IUowSave uowSave)
        {
            _account = account;

            _uowSave = uowSave;
        }
        public void Add(Account t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account t)
        {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            var gstr = _account.GetById(id);

            return gstr;
        }

        public void Multipart(List<Account> t)
        {
            _account.Multipart(t);

            _uowSave.Save();
        }

        public void Update(Account t)
        {
            throw new NotImplementedException();
        }
    }
}
