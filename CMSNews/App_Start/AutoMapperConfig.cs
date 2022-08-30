using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CMSNews.Models.Models;
using CMSNews.Models.ViewModels;

namespace CMSNews.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void ConfigureMapping()
        {
            MapperConfiguration config = new MapperConfiguration(t => {
                t.CreateMap<NewsGroup,NewsGroupViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<NewsGroupViewModel, NewsGroup>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<News, NewsViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<NewsViewModel, News>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Comment, CommentViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<CommentViewModel, Comment>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<User, UserViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<UserViewModel, User>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            mapper = config.CreateMapper();
        }

    }
}