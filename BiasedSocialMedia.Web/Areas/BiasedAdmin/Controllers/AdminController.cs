using BiasedSocialMedia.Web.Repository;
using BiasedSocialMedia.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiasedSocialMedia.Web.Areas.BiasedAdmin.Controllers
{
    public class AdminController : Controller
    {
        // GET: BiasedAdmin/Admin
        private readonly IAnalyticsData data;
        public AdminController(IAnalyticsData data)
        {
            this.data = data;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDashboarData()
        {
            return Json(new { data = data.AdminDashboardData() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetGenderStatus()
        {

            return Json(new { data = data.MaleFemaleData() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPostCountByDate()
        {
            return Json(new { data = data.GetCountOfPostsByDate() }, JsonRequestBehavior.AllowGet);
        }
    }
}