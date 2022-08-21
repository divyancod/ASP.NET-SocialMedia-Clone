using BiasedSocialMedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BiasedSocialMedia.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            //Validation
            return RedirectToAction("Dashboard");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string email, string password)
        {
            return RedirectToAction("NextStep");
        }
        public ActionResult NextStep()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NextStep(string name, string phone, string gender, string username)
        {
            return RedirectToAction("ProfilePhoto");
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
        public ActionResult ProfilePhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadProfilePhoto(int? id)
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
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerSavePath = Path.Combine(Server.MapPath("~/Uploads/") + InputFileName);
                            file.SaveAs(ServerSavePath);
                        }
                    }
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    isSuccess = false;
                }
            }else if(id!=0)
            {
                isSuccess = true;
            }
            return Json(new { isSuccess = isSuccess });
        }
    }
}