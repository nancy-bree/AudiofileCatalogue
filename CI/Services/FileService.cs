using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CI.Properties;

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
                    file.SaveAs(path);
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
    }
}