using BiasedSocialMedia.Web.Models;
using BiasedSocialMedia.Web.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace BiasedSocialMedia.Web.Utilities
{
    public class ImageHelper : IImageHelper
    {
        //TODO:
        // One method for parsing the byte from DB and forwading the parsed data to URL
        // one method for generating the required URL
        private DataRepository dataRepository;
        public ImageHelper(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task<byte[]> GetImageFromDB(int id)
        {
            if (await isFileCached(id))
            {
                return await ReadFromCache(id);
            }
            var model = await dataRepository.MediaInfo.FirstOrDefaultAsync(x => x.MediaID == id);
            if (model != null)
            {
                WriteTextAsync(model.Data, "c:\\MyServerCache\\" + model.MediaID + ".jpeg");
                return model.Data;
            }
            return null;
        }
        async Task<byte[]> ReadFromCache(int id)
        {
            byte[] result;
            using (FileStream stream = File.Open("c:\\MyServerCache\\" + id + ".jpeg", FileMode.Open))
            {
                result = new byte[stream.Length];
                await stream.ReadAsync(result, 0, (int)stream.Length);
            }
            return result;
        }
        async Task<bool> isFileCached(int id)
        {
            bool exists = await Task.Run(() => File.Exists("c:\\MyServerCache\\" + id + ".jpeg"));
            return exists;
        }
        async void WriteTextAsync(byte[] encodedText, string filename)
        {
            try
            {
                using (FileStream sourceStream = new FileStream(filename,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                {
                    await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public int InsertImageToDB(HttpPostedFileBase file)
        {
            ImageUploadModel model = new ImageUploadModel();
            if (file != null)
            {
                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);
                byte[] imgData = ms.ToArray();
                string extension = Path.GetExtension(file.FileName);
                string fileName = "Image-" + DateTime.Now.ToString() + extension;
                model.Data = imgData;
                model.FileName = fileName;
                dataRepository.MediaInfo.Add(model);
                dataRepository.SaveChanges();
                return model.MediaID;
            }
            return 0;
        }

        public async Task<byte[]> GetImageFromDBByUserId(int userid)
        {
            Users users = dataRepository.Users.Find(userid);
            return await GetImageFromDB(users.ProfilePhotoID);
        }

        public async Task<int> InsertImageToDbAsync(HttpPostedFileBase file)
        {
            ImageUploadModel model = new ImageUploadModel();
            if (file != null)
            {
                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);
                byte[] imgData = ms.ToArray();
                string extension = Path.GetExtension(file.FileName);
                string fileName = "Image-" + DateTime.Now.ToString() + extension;
                model.Data = imgData;
                model.FileName = fileName;
                dataRepository.MediaInfo.Add(model);
                await dataRepository.SaveChangesAsync();
                return model.MediaID;
            }
            return 0;
        }

        public byte[] GetDefaultImage()
        {
            return File.ReadAllBytes("c:\\MyServerCache\\default.jpeg");
        }
    }
}