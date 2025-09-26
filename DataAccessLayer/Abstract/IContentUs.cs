using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IContentUs:IGeneric<ContentUs>
    {
        public List<ContentUs> TrueContentUsList();
        public List<ContentUs> FalseContentUsList();
        public void ChangeTrueContentUs(int id);
        public void ChangeFalseContentUs(int id);
        
    }
}
