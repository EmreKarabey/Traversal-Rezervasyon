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
    public class CommentManager : ICommentServices
    {
        IComment _comment;

        public CommentManager(IComment comment)
        {
            _comment = comment;
        }
        public void Add(Comment t)
        {
            _comment.Add(t);
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> FiltreComments(int id)
        {
            var gstr = _comment.GetListFiltre(n => n.DestinationID == id).ToList();

            return gstr;
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> list()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
