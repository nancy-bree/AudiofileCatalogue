using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CI.Properties;
using System.Web.Helpers;

namespace CI.Services
{
    public static class FileService
    {
        public static string SaveFile(HttpPostedFileBase file)
        {
            string path;
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            switch (file.ContentType)
            {
                case "audio/mpeg":
                    path = GetAudiofilePath(filename);
                    file.SaveAs(path);
                    break;
                case "image/jpeg":
                    path = GetImagePath(filename);
                    SaveImage(file, path);
                    /*file.SaveAs(path);*/

                    break;
            }
            return filename;
        }

        private static string GetAudiofilePath(string filename)
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(Settings.Default.AudiofilePath), filename);
        }

        private static string GetImagePath(string filename)
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(Settings.Default.AuthorImagePath), filename);
        }

        private static void SaveImage(HttpPostedFileBase file, string filename)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > Settings.Default.MaxAuthorImageWidth)
            {
                int newWidth = Settings.Default.MaxAuthorImageWidth;
                float aspectRatio = (float)img.Width / (float)img.Height;
                int newHeight = Convert.ToInt32(newWidth / aspectRatio);
                img.Resize(newWidth, newHeight).Crop(1, 1);
                img.Save(filename);
            }
        }
    }
}