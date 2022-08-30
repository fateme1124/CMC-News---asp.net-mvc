using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSNews.Service.Service;
using CMSNews.Models.Context;
using CMSNews.Models.Models;

namespace CMSNews.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}