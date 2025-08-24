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
    public class ContactManager : IContactServices
    {
        private readonly IContact _IContact;

        public ContactManager(IContact contact)
        {
            _IContact = contact;
        }
        public void Add(Contact t)
        {
            _IContact.Add(t);
        }

        public void Delete(Contact t)
        {
            _IContact.Delete(t);
        }

        public Contact GetById(Contact t)
        {
            throw new NotImplementedException();
        }

        public List<Contact> list()
        {
            var gstr = _IContact.list();

            return gstr;
        }

        public void Update(Contact t)
        {
            _IContact.Update(t);
        }
    }
}
