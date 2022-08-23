using BiasedSocialMedia.Web.Models;
using BiasedSocialMedia.Web.Utilities;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BiasedSocialMedia.Web.Controllers
{
    public class LoginController : Controller
    {
        private IImageHelper imageHelper;
        private IUserData userData;
        public LoginController(IImageHelper imageHelper, IUserData userData)
        {
            this.imageHelper = imageHelper;
            this.userData = userData;
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            //Validation
            Users user = userData.LoginUser(email, password);
            if (user == null)
            {
                return View();
            }
            FormsAuthentication.SetAuthCookie(user.ID.ToString(), true);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string email, string password)
        {
            int userid = userData.addUser(email, password);
            FormsAuthentication.SetAuthCookie(userid.ToString(), true);
            return RedirectToAction("NextStep", new { id = userid });
        }
        [Authorize]
        public ActionResult NextStep(int id)
        {
            ViewBag.UserID = id;
            return View();
        }
        [HttpPost]
        public ActionResult NextStep(string userid, string name, string phone, string gender, string username)
        {
            userData.updateData(userid, name, phone, gender, username);
            return RedirectToAction("ProfilePhoto", new { id = userid });
        }
        public ActionResult CheckUserName(string username)
        {
            bool isSuccess = true;
            if (username == "google")
                isSuccess = false;
            return Json(new { isSuccess = isSuccess }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Dashboard()
        {
            ViewBag.show = true;
            return View();
        }
        public ActionResult _WelcomeScreen()
        {
            return View();
        }
        [Authorize]
        public ActionResult ProfilePhoto(string id)
        {
            ViewBag.UserID = id;
            return View();
        }

        [HttpPost]
        public ActionResult UploadProfilePhoto(string userid, int imageId)
        {
            bool isSuccess = false;
            if (Request.Files.Count > 0)
            {
                try
                {
                    var files = Request.Files;
                    foreach (string str in files)
                    {
                        HttpPostedFileBase file = Request.Files[str] as HttpPostedFileBase;
                        imageId = imageHelper.InsertImageToDB(file);
                    }
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    isSuccess = false;
                }
            }
            else if (imageId != 0)
            {
                isSuccess = true;
            }
            userData.UpdateUserImage(userid, imageId);
            return Json(new { isSuccess = isSuccess });
        }
        public ActionResult GetImage(int id)
        {
            return File(imageHelper.GetImageFromDB(id), "image/jpeg"); ;
        }
        [NonAction]
        private HttpCookie CreateUserIdCookie(string userID)
        {
            HttpCookie UserIDCookie = new HttpCookie("UserIDCookie");
            UserIDCookie.Value = userID;
            UserIDCookie.Expires = DateTime.Now.AddHours(1);
            return UserIDCookie;
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}