using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentServices:IGenericServices<Comment>
    {
        public List<Comment> FiltreComments(int id); 
    }
}
