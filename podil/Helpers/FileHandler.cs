using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace podil.Helpers
{
    public class FileHandler
    {
        public static readonly string PhotosFolderPath = System.Web.Configuration.WebConfigurationManager.AppSettings["PhotosFolderPath"];

        public static void DeletePhotoFile(string fileName)
        {
            string photoFullPath = Path.Combine(GetPhotoFolderPath().FullName, fileName);
            if (System.IO.File.Exists(photoFullPath))
            {
                System.IO.File.Delete(photoFullPath);
            }
        }

        public static DirectoryInfo GetPhotoFolderPath()
        {
            try
            {
                return Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath(PhotosFolderPath));
            }
            catch
            {
                throw;
            }
        }
    }
}