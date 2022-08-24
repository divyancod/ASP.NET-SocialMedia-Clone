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
    public class ProfileController : Controller
    {
        // GET: Profile
        private IUserData userData;
        private IPostHelper postHelper;
        public ProfileController(IImageHelper imageHelper, IUserData userData, IPostHelper postHelper)
        {
            this.userData = userData;
            this.postHelper = postHelper;
        }
        public ActionResult Index()
        {
            ProfileViewModel model = new ProfileViewModel();
            var userid = Convert.ToInt32(User.Identity.Name);
            model.CurrentUser = userData.getUser(userid);
            model.UserPosts = postHelper.GetAllPosts().Where(x=>x.UserId==userid).ToList();
            return View(model);
        }
    }
}