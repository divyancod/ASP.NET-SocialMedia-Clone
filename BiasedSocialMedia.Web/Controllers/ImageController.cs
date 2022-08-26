using BiasedSocialMedia.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiasedSocialMedia.Web.Controllers
{
    public class ImageController : Controller
    {
        private IImageHelper imageHelper;
        public ImageController(IImageHelper imageHelper)
        {
            this.imageHelper = imageHelper;
        }
        // GET: Image
        public ActionResult Images(int? id)
        {
            if(id==null)
            {
                id = 1;
            }
            return File(imageHelper.GetImageFromDB(Convert.ToInt32(id)),"image/jpeg");
        }
        public ActionResult ImageByUserId(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            return File(imageHelper.GetImageFromDBByUserId(Convert.ToInt32(id)), "image/jpeg");
        }
    }
}