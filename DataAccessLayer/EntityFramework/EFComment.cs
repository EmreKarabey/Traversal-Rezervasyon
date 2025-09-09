using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFComment : GenericRepository<Comment>, IComment
    {
        public List<Comment> IncludeCommentList()
        {
            using var c = new Context();

            var gstr = c.Comments.Include(N => N.Destination).ToList();

            return gstr;
        }
    }
}
