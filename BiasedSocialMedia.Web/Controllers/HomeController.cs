using BiasedSocialMedia.Web.Models;
using BiasedSocialMedia.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiasedSocialMedia.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IUserData userData;
        private IImageHelper imageHelper;
        public HomeController(IImageHelper imageHelper, IUserData userData)
        {
            this.imageHelper = imageHelper;
            this.userData = userData;
        }

        public ActionResult Index()
        {
            var userid = User.Identity.Name;
            Users user = userData.getUser(Convert.ToInt32(User.Identity.Name));
            return View(user);
        }

        public ActionResult _DashboardUserInfo()
        {
            return View();
        }
        public ActionResult _NotificationArea()
        {
            return View();
        }
        public ActionResult _SingleNotification()
        {
            return View();
        }
        public ActionResult _PostArea()
        {
            return View();
        }
        public ActionResult _SinglePost()
        {
            return View();
        }
        public ActionResult _WritePost()
        {
            return View();
        }
    }
}