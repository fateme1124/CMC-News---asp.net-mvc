using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
using CMSNews.Repository.Repository;

namespace CMSNews.Service.Service
{
    public class NewsService : GenericService<News>, INewsService
    {
        NewsRepository _newsRepository;
        public NewsService(DbCMSNewsContext context) : base(context)
        {
            _newsRepository = new NewsRepository(context);
        }

        public List<News> GetLastNews(int count)
        {
            return _newsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(u => u.NewsId).Take(count).ToList();
        }

        public List<News> GetBestNews(int count)
        {
            return _newsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(u => u.See).Take(count).ToList();
        }

        
    }
}
