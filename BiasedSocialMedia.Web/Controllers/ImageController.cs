using BiasedSocialMedia.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Images(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            byte[] img = await imageHelper.GetImageFromDB(Convert.ToInt32(id));
            return File(img, "image/jpeg");
        }
        public async Task<ActionResult> ImageByUserId(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            byte[] img = await imageHelper.GetImageFromDBByUserId(Convert.ToInt32(id));
            if(img==null)
            {
                return File(imageHelper.GetDefaultImage(), "image/jpeg"); ;
            }
            return File(img, "image/jpeg");
        }
    }
}