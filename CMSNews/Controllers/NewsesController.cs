using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSNews.Service.Service;
using CMSNews.Models.Models;
using CMSNews.Models.ViewModels;
using CMSNews.Models.Context;
using CMSNews.App_Start;
using CMSNews.Classes;

namespace CMSNews.Controllers
{
    public class NewsesController : Controller
    {
        DbCMSNewsContext db = new DbCMSNewsContext();
        NewsGroupService _newsGroupService;
        NewsService _newsService;

        public NewsesController()
        {
            _newsGroupService = new NewsGroupService(db);
            _newsService = new NewsService(db);
        }

        public ActionResult ShowNewsGroup(int locId)
        {
            ViewBag.LocId = locId;
            var newsGroups = _newsGroupService.GetAll();
            List<NewsGroupViewModel> newsGroupViewModels = AutoMapperConfig.mapper.Map<IEnumerable<NewsGroup>, List<NewsGroupViewModel>>(newsGroups);
            return PartialView(newsGroupViewModels);
        }

        public ActionResult LastNews(int count)
        {
            var lastNews = _newsService.GetLastNews(count);
            List<NewsViewModel> lastNewsViewModel = lastNews.ToNewsViewModels();
            return PartialView(lastNewsViewModel);
        }

        /// <summary>
        /// به تعداد ورودی اخباری که بیشترین بازدید را داشته بر  می گرداند
        /// </summary>
        /// <param name="count">تعداد اخبار قابل نمیش</param>
        /// <returns></returns>
        public ActionResult BestNews(int count)
        {
            var bestNews = _newsService.GetBestNews(count);
            List<NewsViewModel> bestNewsViewModel = bestNews.ToNewsViewModels();
            return PartialView(bestNewsViewModel);
        }

        /// <summary>
        /// اخرین خبر درج شده در سایت
        /// </summary>
        /// <returns>نمایش یک پارشیال پیج</returns>
        public ActionResult LastNews1()
        {
            var lastNews = _newsService.GetAll().Where(t => t.IsActive).ToList().LastOrDefault();
            NewsViewModel lastNewsViewModel = lastNews.ToNewsViewModel();
            return PartialView(lastNewsViewModel);
        }

        public ActionResult NewsDetails(int id)
        {
            var news = _newsService.GetEntity(id);
            if (news == null || !news.IsActive)
            {
                return HttpNotFound();
            }

            news.See++;
            _newsService.Update(news);
            _newsService.Save();

            NewsViewModel newsViewModel = news.ToNewsViewModel();
            return View(newsViewModel);
        }


        public ActionResult ShowLike(int newsId, bool state)
        {
            var news = _newsService.GetEntity(newsId);
            NewsLikeViewModel newsLikeViewModel = new NewsLikeViewModel()
            {
                NewsId = newsId,
                Like = news.Like,
                NewsState = state
            };
            return PartialView(newsLikeViewModel);
        }


        public ActionResult ChangeLikeState(int newsId, bool state)
        {
            var news = _newsService.GetEntity(newsId);
            news.Like = (state) ? (news.Like-1) : (news.Like+1);
            _newsService.Update(news);
            _newsService.Save();
            return RedirectToAction("ShowLike",new {newsId,state });
        }


        public ActionResult ShowNewsList(int? id)    //id is NewsGroupId
        {
            var listNews=_newsService.GetAll().Where(t => t.IsActive).OrderByDescending(t => t.RegisterDate).ToList();
            if (id != null)
            {
                listNews=listNews.Where(t => t.NewsGroupId == id).ToList();
            }
            List<NewsViewModel> lastNewsViewModel = AutoMapperConfig.mapper.Map<IEnumerable<News>, List<NewsViewModel>>(listNews);
            return View(lastNewsViewModel);
        }
    }
}