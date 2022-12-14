using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Models;
namespace CMSNews.Service.Service
{
    public interface INewsService:IGenericService<News>
    {
        List<News> GetLastNews(int count);
        List<News> GetBestNews(int count);
    }
}
