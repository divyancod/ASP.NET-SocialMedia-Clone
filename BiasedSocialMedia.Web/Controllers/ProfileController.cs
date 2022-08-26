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
        public ActionResult Index(int? id)
        {
            //ProfileViewModel model = new ProfileViewModel();
            //var userid = Convert.ToInt32(User.Identity.Name);
            //model.CurrentUser = userData.getUser(userid);
            return View();
        }
        public ActionResult LoadProfileInfo(int? id)
        {
            if (id != null && id != 0)
            {
                int currentID = Convert.ToInt32(id);
                var userInfo = userData.getUser(currentID);
                if (currentID == Convert.ToInt32(User.Identity.Name))
                {
                    return PartialView("_EditProfile", userInfo);
                }
                else
                {
                    return PartialView("_FriendProfile", userInfo);
                }
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateProfile(Users user)
        {
            userData.updateData(user.ID.ToString(), user.Name, user.PhoneNumber, user.Gender, user.UserName);
            return Json(new {isSuccess=true});
        }
    }
}