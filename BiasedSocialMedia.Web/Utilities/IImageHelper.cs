using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    public interface IImageHelper
    {
        int InsertImageToDB(HttpPostedFileBase file);
        byte[] GetImageFromDB(int id);
        byte[] GetImageFromDBByUserId(int userid);
        Task<int> InsertImageToDbAsync(HttpPostedFileBase file);
    }
}
