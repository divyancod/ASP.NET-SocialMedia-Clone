using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiasedSocialMedia.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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