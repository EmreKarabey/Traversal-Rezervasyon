using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.UnitOfWork
{
    public class UowSave : IUowSave
    {
        private readonly Context _context;

        public UowSave(Context context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
