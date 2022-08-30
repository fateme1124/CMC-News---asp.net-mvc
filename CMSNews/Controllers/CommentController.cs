using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSNews.Service.Service;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
using CMSNews.Models.ViewModels;
using CMSNews.App_Start;

namespace CMSNews.Controllers
{
    public class CommentController : Controller
    {
        DbCMSNewsContext db = new DbCMSNewsContext();
        CommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentService(db);
        }
        public ActionResult ShowComments(int id)   //id is NewsId
        {
            var comments=_commentService.GetAll().Where(t => t.IsActive && t.NewsId == id).OrderByDescending(u=>u.CommentId).ToList();
            var commentViewModels=AutoMapperConfig.mapper.Map<IEnumerable<Comment>, List<CommentViewModel>>(comments);
            return PartialView(commentViewModels);
        }

        public ActionResult CreateComment(int id)   //id is NewsId
        {
            var commentViewModels = new CommentViewModel();
            commentViewModels.NewsId = id;
            return PartialView(commentViewModels);
        }

        [HttpPost]
        public ActionResult CreateComment([Bind(Include = "NewsId,Name,Email,CommentText")] CommentViewModel commentViewModel)   
        {
            if(ModelState.IsValid)
            {
                Comment comment = AutoMapperConfig.mapper.Map<CommentViewModel, Comment>(commentViewModel);
                comment.RegisterDate = DateTime.Now;
                comment.IsActive = false;
                _commentService.Add(comment);
                _commentService.Save();
                return RedirectToAction("ShowComments",new {id=comment.NewsId });
            }
            return PartialView(commentViewModel);
        }
    }
}