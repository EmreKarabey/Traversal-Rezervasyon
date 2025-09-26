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

namespace DataAccessLayer.EntityFramework
{
    public class EFContentUs : GenericRepository<ContentUs>, IContentUs
    {
        public void ChangeFalseContentUs(int id)
        {
            using var c = new Context();

            var gstr = c.ContentUs.Find(id);

            gstr.Status = false;

            c.ContentUs.Update(gstr);
        }

        public void ChangeTrueContentUs(int id)
        {
            using var c = new Context();

            var gstr = c.ContentUs.Find(id);

            gstr.Status = true;

            c.ContentUs.Update(gstr);
        }

        public List<ContentUs> FalseContentUsList()
        {
            using var c = new Context();

            var gstr = c.ContentUs.Where(n => n.Status == false).ToList();

            return gstr;

          
        }

        public List<ContentUs> TrueContentUsList()
        {
            using var c = new Context();

            var gstr = c.ContentUs.Where(n => n.Status == true).ToList();

            return gstr;
        }
    }
}
