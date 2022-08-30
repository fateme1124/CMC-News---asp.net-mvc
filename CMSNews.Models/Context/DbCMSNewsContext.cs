using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Models;

namespace CMSNews.Models.Context
{
    public class DbCMSNewsContext:DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsGroup> NewsGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
