﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
namespace CMSNews.Repository.Repository
{
    public class NewsRepository : GenericRepository<News>
    {
        public NewsRepository(DbCMSNewsContext context) : base(context)
        {
        }
    }
}
