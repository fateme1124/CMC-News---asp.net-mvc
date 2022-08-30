using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMSNews.Models.ViewModels;
using CMSNews.Models.Models;
using CMSNews.App_Start;

namespace CMSNews.Classes
{
    public static class ExtensionClass
    {
        public static NewsViewModel ToNewsViewModel(this News news)
        {
            return AutoMapperConfig.mapper.Map<News, NewsViewModel>(news);
        }
        public static List<NewsViewModel> ToNewsViewModels(this IEnumerable<News> news)
        {
            return AutoMapperConfig.mapper.Map<IEnumerable<News>, List<NewsViewModel>>(news);
        }

            
    }
}