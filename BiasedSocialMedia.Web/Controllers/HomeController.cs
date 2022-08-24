﻿using BiasedSocialMedia.Web.Models;
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
        private IPostHelper postHelper;
        public HomeController(IImageHelper imageHelper, IUserData userData, IPostHelper postHelper)
        {
            this.imageHelper = imageHelper;
            this.userData = userData;
            this.postHelper = postHelper;
        }

        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            var userid = User.Identity.Name;
            model.CurrentUser = userData.getUser(Convert.ToInt32(User.Identity.Name));
            //model.Posts = postHelper.GetAllPosts();
            return View(model);
        }

        #region Child actions
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
            return PartialView(postHelper.GetAllPostByPage(0));
        }
        public ActionResult _SinglePost()
        {
            return View();
        }
        public ActionResult _WritePost()
        {
            return View();
        }
        #endregion

        #region PostRegion
        [HttpPost]
        public ActionResult SubmitPost(Posts post)
        {
            postHelper.CreatePost(Convert.ToInt32(User.Identity.Name), post);
            return PartialView("_PostArea", postHelper.GetAllPosts());
        }
        #endregion

        public ActionResult GetPostArea(int page)
        {
            return PartialView("_PostArea", postHelper.GetAllPostByPage(page));
        }
        public ActionResult LikePost(int? postId, int? status)
        {
            Dictionary<string, int> counts = postHelper.LikePost(Convert.ToInt32(postId), Convert.ToInt32(status), Convert.ToInt32(User.Identity.Name));
            bool isSuccess = true;
            if (counts == null)
                isSuccess = false;
            return Json(new { counts, isSuccess = isSuccess }, JsonRequestBehavior.AllowGet);
        }
    }
}