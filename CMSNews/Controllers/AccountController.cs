using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CMSNews.Models.Context;
using CMSNews.Models.ViewModles;
using CMSNews.Service.Service;

namespace AreaWebApplication1.Controllers
{
    public class AccountController : Controller
    {
        DbCMSNewsContext db = new DbCMSNewsContext();
        private UserService _userService;
        public AccountController()
        {
            _userService = new UserService(db);
        }
        public ActionResult Login(string returnUrl = "/")
        {
            LoginViewModel login = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "MobileNumber,Password,ReturnUrl,RememberPassword")] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetAll().FirstOrDefault(t => t.MobileNumber == login.MobileNumber && t.Password == login.Password);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(login.MobileNumber, login.RememberPassword);
                        return Redirect(login.ReturnUrl);
                    }
                    ModelState.AddModelError("MobileNumber", "حساب کاربری شما فعال نمی باشد");
                }
                ModelState.AddModelError("MobileNumber", "نام کاربری یا رمز عبور شما اشتباه است");
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }


        public ActionResult LoginState()
        {
            ViewBag.LoginState = false;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.LoginState = true;
            }
            return PartialView();
        }
    }
}