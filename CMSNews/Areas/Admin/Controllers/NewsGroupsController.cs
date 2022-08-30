using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSNews.App_Start;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
using CMSNews.Models.ViewModels;
using CMSNews.Service.Service;

namespace CMSNews.Areas.Admin.Controllers
{
    public class NewsGroupsController : Controller
    {
        private DbCMSNewsContext db = new DbCMSNewsContext();
        NewsGroupService _newsGroupService;
        public NewsGroupsController()
        {
            _newsGroupService=new NewsGroupService(db);
        }

        public ActionResult Index()
        {
            var newsGroups = _newsGroupService.GetAll();
            var newsGroupViewModels = AutoMapperConfig.mapper.Map<IEnumerable<NewsGroup>,List<NewsGroupViewModel>>(newsGroups);

            return View(newsGroupViewModels);
        }

        // GET: Admin/NewsGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroup newsGroup = _newsGroupService.GetEntity(id.Value);
            if (newsGroup == null)
            {
                return HttpNotFound();
            }
            var newsGroupViewModel = AutoMapperConfig.mapper.Map<NewsGroup, NewsGroupViewModel>(newsGroup);
            return View(newsGroupViewModel);
        }

        // GET: Admin/NewsGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsGroupTitle")] NewsGroupViewModel newsGroupViewModel,HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                string imageName = "nophoto.png";
                if (imgUpload != null)
                {
                    imageName = Guid.NewGuid().ToString().Replace("-", "") +System.IO.Path.GetExtension(imgUpload.FileName);
                    imgUpload.SaveAs(Server.MapPath("/images/news-group/")+ imageName);
                }
                newsGroupViewModel.ImageName = imageName;
                newsGroupViewModel.NewsGroupId = _newsGroupService.NextNewsGroupId();
                NewsGroup newsGroup = AutoMapperConfig.mapper.Map<NewsGroupViewModel, NewsGroup>(newsGroupViewModel);
                _newsGroupService.Add(newsGroup);
                _newsGroupService.Save();
                return RedirectToAction("Index");
            }

            return View(newsGroupViewModel);
        }

        // GET: Admin/NewsGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroup newsGroup = _newsGroupService.GetEntity(id.Value);
            if (newsGroup == null)
            {
                return HttpNotFound();
            }
            var newsGroupViewModel= AutoMapperConfig.mapper.Map<NewsGroup, NewsGroupViewModel>(newsGroup);
            return View(newsGroupViewModel);
        }

        // POST: Admin/NewsGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsGroupId,NewsGroupTitle,ImageName")] NewsGroupViewModel newsGroupViewModel, HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                if (imgUpload != null)
                {
                    if (newsGroupViewModel.ImageName != "nophoto.png")
                    {
                        System.IO.File.Delete(Server.MapPath("/images/news-group/") + newsGroupViewModel.ImageName);
                    }
                    else
                    {
                        newsGroupViewModel.ImageName = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(imgUpload.FileName);
                    }
                    imgUpload.SaveAs(Server.MapPath("/images/news-group/") + newsGroupViewModel.ImageName);
                }
                NewsGroup newsGroup = AutoMapperConfig.mapper.Map<NewsGroupViewModel, NewsGroup>(newsGroupViewModel);
                _newsGroupService.Update(newsGroup);
                _newsGroupService.Save();
                return RedirectToAction("Index");
            }
            return View(newsGroupViewModel);
        }

        // GET: Admin/NewsGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroup newsGroup = _newsGroupService.GetEntity(id.Value);
            if (newsGroup == null)
            {
                return HttpNotFound();
            }
            var newsGroupViewModel = AutoMapperConfig.mapper.Map<NewsGroup, NewsGroupViewModel>(newsGroup);
            return View(newsGroupViewModel);
        }

        // POST: Admin/NewsGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var newsGroup = _newsGroupService.GetEntity(id);
            _newsGroupService.Delete(id);
            _newsGroupService.Save();
            if (newsGroup.ImageName != "nophoto.png")
            {
                System.IO.File.Delete(Server.MapPath("/images/news-group/") + newsGroup.ImageName);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _newsGroupService.Dispose();
        }
    }
}
