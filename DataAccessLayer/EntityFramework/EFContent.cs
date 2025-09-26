using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccessLayer.EntityFramework
{
    public class EFContent : IContentUs
    {
        public void Add(ContentUs t)
        {
            throw new NotImplementedException();
        }

        public void ChangeFalseContentUs(int id)
        {
            using var c = new Context();

            var gstr = c.ContentUs.Find(id);

            gstr.Status = false;

            c.ContentUs.Update(gstr);

            c.SaveChanges();
        }

        public void ChangeTrueContentUs(int id)
        {
            using var c = new Context();

            var gstr = c.ContentUs.Find(id);

            gstr.Status = true;

            c.ContentUs.Update(gstr);

            c.SaveChanges();
        }

        public void Delete(ContentUs t)
        {
            throw new NotImplementedException();
        }

        public List<ContentUs> FalseContentUsList()
        {
            using var c = new Context();

            var gstr = c.ContentUs.Where(n=>n.Status==false).ToList();

            return gstr;
        }

        public ContentUs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContentUs> GetListFiltre(Expression<Func<ContentUs, bool>> filtre)
        {
            throw new NotImplementedException();
        }

        public List<ContentUs> list()
        {
            throw new NotImplementedException();
        }

        public List<ContentUs> TrueContentUsList()
        {
            using var c = new Context();

            var gstr = c.ContentUs.Where(n=>n.Status==true).ToList();

            return gstr;
        }

        public void Update(ContentUs t)
        {
            throw new NotImplementedException();
        }
    }
}
