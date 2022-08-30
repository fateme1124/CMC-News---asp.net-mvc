using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
namespace CMSNews.Service.Service
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        public CommentService(DbCMSNewsContext context) : base(context)
        {
        }
    }
}
